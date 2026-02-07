using DevExpress.Xpo.DB.Helpers;
using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
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

        public DataTable GetTrashProduits()
        {
            query = "SELECT c_prd as Réf,fourniseur.nom as 'Fournisseur',TRASH_produits.[Nom],[Unit],[Type],DeletedBy as 'Utilisateur' , DeletedAt as 'Date suppression' " +
             "  FROM [TRASH_produits] join fourniseur on fourniseur.c_fr = TRASH_produits.c_fr;";

            return GetTrashTable("TRASH_produits");
        }

        public DataTable GetTrashUsers()
        {
            query = "SELECT N AS Réf, Nom AS \"Nom\", CodeBare AS \"Code barre\"," +
                " isAdmin AS \"Administrateur\", Actif AS \"Actif\", DeletedAt AS \"Date suppression\"," +
                " DeletedBy AS \"Supprimé par\"\r\n FROM TRASH_user;";
            return GetTrashTable("TRASH_user");
        }

        public DataTable GetTrashClients()
        {
            query = "select c_cl as Réf,nom,tel,activite,adresse,Datajout as 'Date d''ajout' from trash_client ";
            return GetTrashTable("TRASH_Client");
        }

        public DataTable GetTrashFournisseurs()
        {
            query = "SELECT c_fr as Réf, nom as Nom,tel as Téléphone, Adresse as Adresse ,email as Email,activite as Activité,dateajout as 'Date d''ajout' " +
                " from trash_fourniseur ";
            return GetTrashTable("TRASH_Fourniseur");
        }

        public DataTable GetTrashVentes()
        {

             query = "SELECT n as Réf,[Type],[DateA] as Date,Trash_Ventes.C_CL as 'Ref client',client.Nom as 'Nom de client ',totalttc as " +
                "Total, totalremise as 'Remise totale',ModeReglement as 'Mode reglement',Regler" +
                " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                " MontantRest as 'Montant reste'," +
                " user FROM [Trash_Ventes]  left join client on Trash_Ventes.C_CL = Client.C_CL left join trash_client on trash_client.c_cl = Trash_Ventes.c_cl  order by Date desc";

            return GetTrashTable("TRASH_Ventes");
        }

        public DataTable GetTrashAchat()
        {
             query = "SELECT n as Réf,[Type],[DateA] as Date,trash_achat.c_fr as 'Reference de fournisseur'," +
            "fourniseur.Nom 'Nom de fournisseur',totalttc as " +
               "Total,ModeReglement,Regler" +
               " as 'Reglée',MontantRegler as 'Montant Réglé'," +
               " MontantRest as 'Montant reste'," +
               " user FROM [Trash_Achat] left  join fourniseur on fourniseur.c_fr = trash_achat.c_fr left join trash_fourniseur on trash_fourniseur.c_fr = trash_achat.c_fr order by Date" +
               " desc ";

            return GetTrashTable("TRASH_Achat");
        }

        private DataTable GetTrashTable(string tableName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving {tableName}: {ex.Message}");
            }
            return dt;
        }

        public void Dispose()
        {

        }

        internal void PermanentlyDelete(string page, string selectedId)
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

            // SQL query to permanently delete the item from the Trash table
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
                            MessageBoxer.showGeneralMsg("L’élément a été supprimé définitivement");
                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s’est produite lors de la suppression définitive");
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



        internal void RestoreFromTrash(string page, string selectedId)
        {
            string sourceTable;
            string destinationTable;
            page = page.ToLower();
            string idColumn;
            string[] columns;


            switch (page)
            {
                case "purchases":
                    sourceTable = "Trash_Achat";
                    destinationTable = "Achat";
                    idColumn = "N";
                    columns = new[]
                    {
            "N","Type","DateA","C_FR","TotalTTC","ModeReglement","Regler","MontantRegler","MontantRest","TauxTVA","User"
        };
                    break;

                case "sales":
                    sourceTable = "TRASH_Ventes";
                    destinationTable = "Ventes";
                    idColumn = "N";
                    columns = new[]
                    {
            "N","Type","DateA","C_CL","TotalTTC","TotalRemise","ModeReglement","Regler","MontantRegler","MontantRest","TauxTVA","User","Benefice"
        };
                    break;

                case "suppliers":
                    sourceTable = "TRASH_Fourniseur";
                    destinationTable = "Fourniseur";
                    idColumn = "C_FR";
                    columns = new[]
                    {
            "C_FR","Nom","Activite","Adresse","Tel","Fax","Email","RC","NIS","NIF","Solde","CA","Ecart","dateajout"
        };
                    break;

                case "clients":
                    sourceTable = "TRASH_Client";
                    destinationTable = "Client";
                    idColumn = "C_CL";
                    columns = new[]
                    {
            "C_CL","Nom","Activite","Adresse","Tel","Fax","Email","RC","NIS","NIF","Solde","CA","Ecart","DatAjout"
        };
                    break;

                case "users":
                    sourceTable = "TRASH_user";
                    destinationTable = "user";
                    idColumn = "N";
                    columns = new[]
                    {
            "N","Nom","Pass","CodeBare","isAdmin","Actif"
        };
                    break;

                case "produits":
                    sourceTable = "TRASH_produits";
                    destinationTable = "produits";
                    idColumn = "C_Prd";
                    columns = new[]
                    {
            "C_Prd","C_Bare","Nom","Unit","Type","Prix_Achat","TVA","Marge","Prix_VenteHT","PrixVGros","Prix_VenteTTC","Q_Stock","Photo","Stock_Alerte","dateajout","c_fr"
        };
                    break;

                default:
                    throw new InvalidOperationException($"Unknown trash page suffix: {page}");
            }

            string columnList = string.Join(", ", columns);

            string insertQuery = $@"
                INSERT INTO {destinationTable} ({columnList})
                SELECT {columnList} FROM {sourceTable}
                WHERE {idColumn} = @Id";

            string deleteQuery = $@"
                DELETE FROM {sourceTable}
                WHERE {idColumn} = @Id";


            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery +"; "+deleteQuery + ";", conn))
                    {
                        cmd.Parameters.Add(new SQLiteParameter("@Id", selectedId));

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBoxer.showGeneralMsg("L’élément est récupéré");
                        }
                        else
                        {
                            MessageBoxer.showErrorMsg("Une erreur s’est produite");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error recovering item");
            }

        }
    }
}
