using DevExpress.Xpo.DB.Helpers;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aromapp
{
    internal class TrashDBHelper :DBHelper, IDisposable
    {
        string query = "";

        private static readonly Dictionary<string, TableConfig
                   > TrashTables
           = new Dictionary<string, TableConfig
               >(StringComparer.OrdinalIgnoreCase)
           {
               ["purchases"] = new TableConfig

               {
                   SourceTable = "trash_achat",
                   DestinationTable = "achat",
                   IdColumn = "N",
                   Columns = new[]
               {
            "N","Type","DateA","C_FR","TotalTTC","ModeReglement",
            "Regler","MontantRegler","MontantRest","TauxTVA","User"
               }
               },

               ["sales"] = new TableConfig

               {
                   SourceTable = "trash_ventes",
                   DestinationTable = "ventes",
                   IdColumn = "N",
                   Columns = new[]
               {
            "N","Type","DateA","C_CL","TotalTTC","TotalRemise",
            "ModeReglement","Regler","MontantRegler","MontantRest",
            "TauxTVA","User","Benefice"
               }
               },

               ["suppliers"] = new TableConfig

               {
                   SourceTable = "trash_fourniseur",
                   DestinationTable = "fourniseur",
                   IdColumn = "C_FR",
                   Columns = new[]
               {
            "C_FR","Nom","Activite","Adresse","Tel","Fax","Email",
            "RC","NIS","NIF","Solde","CA","Ecart","dateajout"
               }
               },

               ["clients"] = new TableConfig

               {
                   SourceTable = "trash_client",
                   DestinationTable = "client",
                   IdColumn = "C_CL",
                   Columns = new[]
               {
            "C_CL","Nom","Activite","Adresse","Tel","Fax","Email",
            "RC","NIS","NIF","Solde","CA","Ecart","DatAjout"
               }
               },

               ["users"] = new TableConfig

               {
                   SourceTable = "trash_user",
                   DestinationTable = "user",
                   IdColumn = "N",
                   Columns = new[]
               {
            "N","Nom","Pass","CodeBare","isAdmin","Actif"
               }
               },

               ["produits"] = new TableConfig

               {
                   SourceTable = "trash_produits",
                   DestinationTable = "produits",
                   IdColumn = "C_Prd",
                   Columns = new[]
               {
            "C_Prd","C_Bare","Nom","Unit","Type","Prix_Achat","TVA",
            "Marge","Prix_VenteHT","PrixVGros","Prix_VenteTTC",
            "Q_Stock","Photo","Stock_Alerte","dateajout","c_fr"
               }
               }
           };

        private TableConfig GetConfig(string trashTableName)
        {
            if (!TrashTables.TryGetValue(trashTableName.ToLower(), out var config))
                throw new ArgumentException("Invalid trash table name.");

            return config;
        }

        public DataTable GetTrashAchat(DateTime from, DateTime to, string search="")
        {
            query = @"SELECT n as Réf,
                     [Type],
                     [DateA] as Date,
                     trash_achat.c_fr as 'Reference de fournisseur',
                     fourniseur.Nom as 'Nom de fournisseur',
                     totalttc as Total,
                     ModeReglement,
                     Regler as 'Reglée',
                     MontantRegler as 'Montant Réglé',
                     MontantRest as 'Montant reste',
                     [user],
                     trash_achat.DeletedAt as 'Date suppression'
              FROM Trash_Achat
              LEFT JOIN fourniseur ON fourniseur.c_fr = trash_achat.c_fr
              LEFT JOIN trash_fourniseur ON trash_fourniseur.c_fr = trash_achat.c_fr
              WHERE trash_achat.DeletedAt BETWEEN @From AND @To
              AND (fourniseur.Nom LIKE @Search 
                   OR n LIKE @Search)
              ORDER BY Date DESC;";

            return GetTrashTable("TRASH_Achat", from, to, search);
        }

        public DataTable GetTrashVentes(DateTime from, DateTime to, string search = "")
        {
            query = @"SELECT n as Réf,
                     [Type],
                     [DateA] as Date,
                     Trash_Ventes.C_CL as 'Ref client',
                     client.Nom as 'Nom de client',
                     totalttc as Total,
                     totalremise as 'Remise totale',
                     ModeReglement as 'Mode reglement',
                     Regler as 'Reglée',
                     MontantRegler as 'Montant Réglé',
                     MontantRest as 'Montant reste',
                     [user],
                     Trash_Ventes.DeletedAt as 'Date suppression'
              FROM Trash_Ventes
              LEFT JOIN client ON Trash_Ventes.C_CL = Client.C_CL
              LEFT JOIN trash_client ON trash_client.c_cl = Trash_Ventes.c_cl
              WHERE Trash_Ventes.DeletedAt BETWEEN @From AND @To
              AND (client.Nom LIKE @Search 
                   OR n LIKE @Search)
              ORDER BY Date DESC;";

            return GetTrashTable("TRASH_Ventes", from, to, search);
        }

        public DataTable GetTrashFournisseurs(DateTime from, DateTime to, string search = "")
        {
            query = @"SELECT c_fr as Réf,
                     nom as Nom,
                     tel as Téléphone,
                     Adresse as Adresse,
                     email as Email,
                     activite as Activité,
                     dateajout as 'Date d''ajout',
                     DeletedAt as 'Date suppression'
              FROM trash_fourniseur
              WHERE DeletedAt BETWEEN @From AND @To
              AND (nom LIKE @Search 
                   OR c_fr LIKE @Search);";

            return GetTrashTable("TRASH_Fourniseur", from, to, search);
        }

        public DataTable GetTrashClients(DateTime from, DateTime to, string search = "")
        {
            query = @"SELECT c_cl as Réf,
                     nom,
                     tel,
                     activite,
                     adresse,
                     Datajout as 'Date d''ajout',
                     DeletedAt as 'Date suppression'
              FROM trash_client
              WHERE DeletedAt BETWEEN @From AND @To
              AND (nom LIKE @Search 
                   OR c_cl LIKE @Search);";

            return GetTrashTable("TRASH_Client", from, to, search);
        }

        public DataTable GetTrashUsers(DateTime from, DateTime to, string search = "")
        {
            query = @"SELECT N AS Réf,
                     Nom AS 'Nom',
                     CodeBare AS 'Code barre',
                     isAdmin AS 'Administrateur',
                     Actif AS 'Actif',
                     DeletedAt AS 'Date suppression',
                     DeletedBy AS 'Supprimé par'
              FROM TRASH_user
              WHERE DeletedAt BETWEEN @From AND @To
              AND (Nom LIKE @Search 
                   OR N LIKE @Search);";

            return GetTrashTable("TRASH_user", from, to, search);
        }

        public DataTable GetTrashProduits(DateTime from, DateTime to, string search = "")
        {
            query = @"SELECT c_prd as Réf,
                     fourniseur.nom as 'Fournisseur',
                     TRASH_produits.[Nom],
                     [Unit],
                     [Type],
                     DeletedBy as 'Utilisateur',
                     DeletedAt as 'Date suppression'
              FROM TRASH_produits
              JOIN fourniseur ON fourniseur.c_fr = TRASH_produits.c_fr
              WHERE DeletedAt BETWEEN @From AND @To
              AND (TRASH_produits.Nom LIKE @Search 
                   OR c_prd LIKE @Search);";

            return GetTrashTable("TRASH_produits", from, to, search);
        }

        private DataTable GetTrashTable(string tableName, DateTime from, DateTime to, string search = "")
        {
            DataTable dt = new DataTable();
            to = to.Date.AddDays(1);

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                        cmd.Parameters.Add("@To", DbType.DateTime).Value = to;

                        if (string.IsNullOrWhiteSpace(search))
                            search = "";

                        cmd.Parameters.Add("@Search", DbType.String).Value = "%" + search + "%";

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving {tableName}: {ex.Message}");
            }

            return dt;
        }

        public bool PermenantlyDeleteByInterval(string tableName, DateTime from, DateTime to)
        {
            bool success = false;
            to = to.Date.AddDays(1);

            string query = $"DELETE FROM {tableName} " +
                           "WHERE DeletedAt BETWEEN @From AND @To;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                        cmd.Parameters.Add("@To", DbType.DateTime).Value = to;

                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting from {tableName}: {ex.Message}");
                success = false;
            }

            return success;
        }

        public bool RetrieveByInterval(string trashTableName, DateTime from, DateTime to)
        {
            to = to.Date.AddDays(1);

            var config = GetConfig(trashTableName);
            string columnList = string.Join(", ", config.Columns);

            string insertQuery = $@"
                    INSERT INTO {config.DestinationTable} ({columnList})
                    SELECT {columnList}
                    FROM {config.SourceTable}
                    WHERE DeletedAt BETWEEN @From AND @To;
                ";

                        string deleteQuery = $@"
                    DELETE FROM {config.SourceTable}
                    WHERE DeletedAt BETWEEN @From AND @To;
                ";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            using (var insertCmd = new SQLiteCommand(insertQuery, conn, transaction))
                            {
                                insertCmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                                insertCmd.Parameters.Add("@To", DbType.DateTime).Value = to;
                                insertCmd.ExecuteNonQuery();
                            }

                            using (var deleteCmd = new SQLiteCommand(deleteQuery, conn, transaction))
                            {
                                deleteCmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                                deleteCmd.Parameters.Add("@To", DbType.DateTime).Value = to;
                                deleteCmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Interval restore error: {ex.Message}");
                return false;
            }
        }

        private void ExecuteTrashDateCommand(string query, DateTime from, DateTime to)
        {
            to = to.Date.AddDays(1);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                    cmd.Parameters.Add("@To", DbType.DateTime).Value = to;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void ExecuteRecoverCommand(string insertQuery, string deleteQuery, DateTime from, DateTime to)
        {
            to = to.Date.AddDays(1);

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        using (SQLiteCommand insertCmd = new SQLiteCommand(insertQuery, conn, transaction))
                        {
                            insertCmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                            insertCmd.Parameters.Add("@To", DbType.DateTime).Value = to;
                            insertCmd.ExecuteNonQuery();
                        }

                        using (SQLiteCommand deleteCmd = new SQLiteCommand(deleteQuery, conn, transaction))
                        {
                            deleteCmd.Parameters.Add("@From", DbType.DateTime).Value = from;
                            deleteCmd.Parameters.Add("@To", DbType.DateTime).Value = to;
                            deleteCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public bool EmptyAllTrash()
        {
            bool val = false;

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    string[] tables =
                    {
                "TRASH_produits",
                "TRASH_user",
                "trash_client",
                "trash_fourniseur",
                "Trash_Ventes",
                "Trash_Achat"
            };

                    foreach (string table in tables)
                    {
                        using (SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM {table};", conn, transaction))
                        {
                            if (cmd.ExecuteNonQuery() > 1)
                            {
                                val= true;
                                
                            }
                            else
                            {
                                
                                val= false;
                                transaction.Rollback();
                                break;
                            }
                        }
                    }
                    transaction.Commit();
                    return val;

                }
            }
        }


        public void Dispose()
        {

        }

        public void AutoDelete()
        {
            int retentionDays = Properties.Settings.Default.RetentionPeriod;
            DateTime cutoffDate = DateTime.Now.AddDays(-retentionDays);

            string[] pages = { "purchases", "sales", "suppliers", "clients", "users", "produits" };

            foreach (var page in pages)
            {
                string table, idColumn;

                switch (page)
                {
                    case "purchases": table = "Trash_Achat"; idColumn = "N"; break;
                    case "sales": table = "TRASH_Ventes"; idColumn = "N"; break;
                    case "suppliers": table = "TRASH_Fourniseur"; idColumn = "C_FR"; break;
                    case "clients": table = "TRASH_Client"; idColumn = "C_CL"; break;
                    case "users": table = "TRASH_user"; idColumn = "N"; break;
                    case "produits": table = "TRASH_produits"; idColumn = "C_Prd"; break;
                    default: continue;
                }

                var idsToDelete = new List<string>();

                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string selectQuery = $@"
                SELECT {idColumn}
                FROM {table}
                WHERE DeletedAt <= @Cutoff";

                    using (var cmd = new SQLiteCommand(selectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Cutoff", cutoffDate.Date);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                idsToDelete.Add(reader[idColumn].ToString());
                            }
                        }
                    }
                } 

                foreach (var id in idsToDelete)
                {
                    PermanentlyDelete(page, id, auto: true);
                }
            }
        }


        internal void PermanentlyDelete(string page, string selectedId, bool auto=false)
        {
            string sourceTable;
            string idColumn;

            page = page.ToLower();

            switch (page)
            {
                case "purchases":
                    sourceTable = "Trash_Achat";
                    idColumn = "N";
                    break;

                case "sales":
                    sourceTable = "TRASH_Ventes";
                    idColumn = "N";
                    break;

                case "suppliers":
                    sourceTable = "TRASH_Fourniseur";
                    idColumn = "C_FR";
                    break;

                case "clients":
                    sourceTable = "TRASH_Client";
                    idColumn = "C_CL";
                    break;

                case "users":
                    sourceTable = "TRASH_user";
                    idColumn = "N";
                    break;

                case "produits":
                    sourceTable = "TRASH_produits";
                    idColumn = "C_Prd";
                    break;

                default:
                    throw new InvalidOperationException($"Unknown trash page suffix: {page}");
            }

            string deleteQuery = $@"
        DELETE FROM {sourceTable}
        WHERE {idColumn} = @Id";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@Id", selectedId));

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            if(!auto) MessageBoxer.showGeneralMsg("L’élément a été supprimé définitivement");
                        }
                        else
                        {
                            if (!auto) MessageBoxer.showErrorMsg("Une erreur s’est produite lors de la suppression définitive");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error permanently deleting item: {ex.Message}");
                MessageBoxer.showErrorMsg("Une erreur s’est produite lors de la suppression définitive");
            }
        }

        internal void RestoreFromTrash(string trashTableName, string selectedId)
        {
            var config = GetConfig(trashTableName);

            string columnList = string.Join(", ", config.Columns);

            string query = $@"
                        INSERT INTO {config.DestinationTable} ({columnList})
                        SELECT {columnList}
                        FROM {config.SourceTable}
                        WHERE {config.IdColumn} = @Id;

                        DELETE FROM {config.SourceTable}
                        WHERE {config.IdColumn} = @Id;
                    ";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedId);

                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }

                MessageBoxer.showGeneralMsg("L’élément est récupéré");
            }
            catch (Exception ex)
            {
                MessageBoxer.showErrorMsg("Une erreur s’est produite");
                Console.WriteLine($"Restore error: {ex.Message}");
            }
        }

        public int DeleteProduitWithTrash(string id, string deletedBy)
        {
            int done = 0;
            

            string insertTrashQuery = @"
                INSERT INTO TRASH_produits
                (C_Prd, C_Bare, Nom, Unit, Type, Prix_Achat, TVA, Marge,
                 Prix_VenteHT, PrixVGros, Prix_VenteTTC, Q_Stock, Photo,
                 Stock_Alerte, dateajout, c_fr, DeletedBy, DeletedAt)
                SELECT 
                    C_Prd, C_Bare, Nom, Unit, Type, Prix_Achat, TVA, Marge,
                    Prix_VenteHT, PrixVGros, Prix_VenteTTC, Q_Stock, Photo,
                    Stock_Alerte, dateajout, c_fr, @DeletedBy, @DeletedAt
                FROM produits " + ((id != "*") ? "WHERE C_Prd = @Id;" : "");

            string deleteQuery = "DELETE FROM produits "+ ((id != "*") ? "WHERE C_Prd = @Id;" : "");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                try
                {
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        connection.Open();

                        using (var transaction = connection.BeginTransaction())
                        {
                            command.CommandText = insertTrashQuery;
                            command.Parameters.AddWithValue("@Id", id);
                            command.Parameters.AddWithValue("@DeletedBy", deletedBy);
                            command.Parameters.AddWithValue("@DeletedAt", DateTime.Now);
                            command.ExecuteNonQuery();

                            command.CommandText = deleteQuery;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();

                            transaction.Commit();
                            done = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting produit {id}: {ex.Message}");
                    try { connection.Close(); } catch { }
                    done = 0;
                } 
            }

            return done;
        }


    }
}
