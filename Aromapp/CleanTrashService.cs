using System;
using System.Data.SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace Aromapp
{
    public class CleanTrashService : IDisposable
    {
        private readonly string _connectionString;
        private readonly TimeSpan _retentionPeriod;
        private Timer _timer;

        public CleanTrashService(
            string connectionString,
            int retentionDays = 30)
        {
            _connectionString = connectionString;
            _retentionPeriod = TimeSpan.FromDays(retentionDays);
        }

        public void Dispose()
        {
            Stop();
        }

        public void Start(string[] args)
        {
            Task.Run(RunCleanupIfNeeded);

            _timer = new Timer(
                _ => RunCleanupIfNeeded(),
                null,
                TimeSpan.FromHours(1),
                TimeSpan.FromHours(24));
        }

        public void Stop()
        {
            _timer?.Dispose();
            _timer = null;
        }
        private void RunCleanupIfNeeded()
        {
            try
            {
                using (var conn = new SQLiteConnection(_connectionString))
                {
                    conn.Open();

                    EnsureMetadataTable(conn);

                    if (AlreadyRanToday(conn))
                        return;

                    using (var tx = conn.BeginTransaction())
                    {
                        string retentionExpr =
                            "datetime('now', '-" + _retentionPeriod.Days + " days')";

                        string[] cleanupSql =
                        {
                    "DELETE FROM TRASH_Achat WHERE DeletedAt <= " + retentionExpr,
                    "DELETE FROM TRASH_Ventes WHERE DeletedAt <= " + retentionExpr,
                    "DELETE FROM TRASH_Client WHERE DeletedAt <= " + retentionExpr,
                    "DELETE FROM TRASH_Fourniseur WHERE DeletedAt <= " + retentionExpr,
                    "DELETE FROM TRASH_produits WHERE DeletedAt <= " + retentionExpr,
                    "DELETE FROM TRASH_user WHERE DeletedAt <= " + retentionExpr
                };

                        foreach (var sql in cleanupSql)
                        {
                            using (var cmd = new SQLiteCommand(sql, conn, tx))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        UpdateLastRun(conn, tx);
                        tx.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: log error
                Console.WriteLine(ex);
            }
        }

        private static void EnsureMetadataTable(SQLiteConnection conn)
        {
            const string sql = @"
            CREATE TABLE IF NOT EXISTS AppMaintenance (
                Key TEXT PRIMARY KEY,
                Value TEXT
            );";

            new SQLiteCommand(sql, conn).ExecuteNonQuery();
        }
        private static bool AlreadyRanToday(SQLiteConnection conn)
        {
            var cmd = new SQLiteCommand(
                "SELECT Value FROM AppMaintenance WHERE Key='LastCleanup'", conn);

            var last = cmd.ExecuteScalar()?.ToString();

            return last == DateTime.UtcNow.ToString("yyyy-MM-dd");
        }

    
       private static void UpdateLastRun(SQLiteConnection conn, SQLiteTransaction tx)
        {
            var cmd = new SQLiteCommand(
                @"INSERT OR REPLACE INTO AppMaintenance(Key,Value)
              VALUES('LastCleanup', @v)", conn, tx);

            cmd.Parameters.AddWithValue("@v",
                DateTime.UtcNow.ToString("yyyy-MM-dd"));

            cmd.ExecuteNonQuery();
        }
    } 
}
