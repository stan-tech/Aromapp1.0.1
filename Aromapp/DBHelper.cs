using Aromapp.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Aromapp
{


    public class DBHelper : IDisposable
    {
        public static string connectionString = "data source= " + AppDomain.CurrentDomain.BaseDirectory + "Data\\AromatiqueDB.db";

        private bool disposedValue;
        NumberFormatInfo nfi = new NumberFormatInfo();


        public bool IsDisposed
        {
            get; set;
        }


        public DBHelper()
        {
            nfi.NumberDecimalSeparator = ".";
        }


        public DataTable GetProductByType(string type, int limit, int currentPage)
        {
            string query = "SELECT c_prd as Référence,[Nom],[Unit],[Type],PRIX_achat as 'Prix d''achat',[Prix_VenteHT] as " +
            "'Prix en Detail',[PrixVGros] as 'Prix en Gros', [Q_Stock] as 'Disponible' " +
            "  FROM [produits] where type like '" + type + "' order by c_prd asc limit " + limit + " offset " + (currentPage - 1) * limit + ";";


            if (type.ToLower() == "emballage" || type.ToLower() == "sachet")
            {
                query = query.Replace("produits", "emballage").Substring(0, query.LastIndexOf(']') + 1) + "] order by c_prd asc;";
            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }
        public DataTable searchForProduct(string TableName, string search)
        {
            string query = "SELECT c_prd as Référence,fourniseur.nom as 'Fournisseur',produits.[Nom],[Unit],[Type],PRIX_achat as 'Prix d''achat',[Prix_VenteHT] as " +
            "'Prix en Detail',[PrixVGros] as 'Prix en Gros', [Q_Stock] as 'Disponible' " +
            "  FROM [" + TableName + "] inner join fourniseur on fourniseur.c_fr = produits.c_fr where lower(produits.nom) like @search or lower(c_prd) like @search order by c_prd asc;";




            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.SelectCommand.Parameters.Add("@search", (DbType)SqlDbType.VarChar).Value = "%" + search.ToLower().Trim() + "%";

                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }
        public AutoCompleteStringCollection GetProductsNames(string table, string search, out List<Product> products)
        {

            AutoCompleteStringCollection names = new AutoCompleteStringCollection();

            Product prod;
            products = new List<Product>();


            string query = "SELECT c_prd as Référence,[Nom] " +
            "  FROM [" + table + "] where lower(nom) like @search or lower(c_prd) like @search;";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.Add("@search", (DbType)SqlDbType.VarChar).Value = "%" + search.ToLower() + "%";

                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        prod = new Product();
                        prod.ID = reader.GetString(0);
                        prod.Name = reader.GetString(1);
                        names.Add(reader.GetString(1));
                        products.Add(prod);


                    }


                    connection.Close();
                }

            }

            return names;

        }
        public DataTable selectAllProducts(int limit, int currentPage)
        {

            string query = "SELECT c_prd as Référence,fourniseur.nom as 'Fournisseur',produits.[Nom],[Unit],[Type],PRIX_achat as 'Prix d''achat',[Prix_VenteHT] as " +
            "'Prix en Detail',[PrixVGros] as 'Prix en Gros', [Q_Stock] as 'Disponible' " +
            "  FROM [produits] inner join fourniseur on fourniseur.c_fr = produits.c_fr order by c_prd asc limit " + limit + " offset " + (currentPage - 1) * limit + ";";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();
                return table;

            }



        }
        public DataTable searchPOS(string tableName, string search, int limit, int currentPage)
        {

            string query = "SELECT c_prd as Référence,fourniseur.nom as 'Fournisseur',[" + tableName + "].[Nom],[Unit],[Type],PRIX_achat as 'Prix d''achat',[Prix_VenteHT] as"
             + "'Prix en Detail',[PrixVGros] as 'Prix en Gros', [Q_Stock] as 'Disponible'"
            + "FROM[" + tableName + "] inner join fourniseur on fourniseur.c_fr = [" + tableName + "].c_fr where c_prd like @search or produits.nom like @search order by c_prd asc  limit "
                + limit + " offset " + (currentPage - 1) * limit + ";";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.Add("@search", (DbType)SqlDbType.VarChar).Value = "%" + search.ToLower() + "%";

                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }
        public string selectCLientID(string saleID)
        {
            string ID = string.Empty;
            string query = "select c_cl from ventes where N = '" + saleID + "';";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ID = reader.GetString(0);
                }
                connection.Close();
            }

            return ID;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            User user = new User();
            string query = "select n,nom,pass,isAdmin from user;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user = new User();
                    user.Name = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.ID = reader.GetString(0);
                    user.IsAdmin = reader.GetBoolean(3);

                    users.Add(user);
                }
                reader.Close();
                connection.Close();

            }

            return users;



        }
        public DataTable selectSales(int limit, int currentPage, string type)
        {
            type = (type == "T") ? " where n like '" + type + "%'" : string.Empty;

            string query = "SELECT n,[Type],[DateA] as Date,Ventes.C_CL as 'Ref client',client.Nom as 'Nom de client ',totalttc as " +
                "Total, totalremise as 'Remise totale',ModeReglement as 'Mode reglement',Regler" +
                " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                " MontantRest as 'Montant reste'," +
                " user FROM [Ventes]  inner join client on Ventes.C_CL = Client.C_CL  " + type + "order by Date desc  " +
                "  limit " + limit + " offset " + (currentPage - 1) * limit + ";";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }
        internal Client selectClientInfo(string clientID)
        {

            Client client = new Client();

            string query = "select nom, tel,activite,fax, email,adresse  from client where c_cl = '" + clientID + "';";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    client.Nom = reader.GetString(0);
                    if (reader.GetValue(1) != null)
                    {
                        try
                        {
                            client.Tel = (string)reader.GetValue(1);

                        }
                        catch
                        {
                            client.Tel = "Non disponible";
                        }
                    }

                    if (reader.GetValue(2) != null)
                    {
                        try
                        {
                            client.Activite = (string)reader.GetValue(2);
                        }
                        catch
                        {
                            client.Activite = "Non disponible";
                        }
                    }
                    if (reader.GetValue(3) != null)
                    {
                        try
                        {
                            client.Fax = (string)reader.GetValue(3);
                        }
                        catch
                        {
                            client.Fax = "Non disponible";
                        }

                    }
                    if (reader.GetValue(4) != null)
                    {
                        try
                        {
                            client.Email = (string)reader.GetValue(4);

                        }
                        catch
                        {
                            client.Email = "Non disponible";
                        }
                    }
                    if (reader.GetValue(5) != null)
                    {
                        try
                        {
                            client.Adresse = (string)reader.GetValue(5);

                        }
                        catch
                        {
                            client.Adresse = "Non disponible";
                        }
                    }

                }

                reader.Close();
                connection.Close();
            }

            return client;
        }
        public int UpdatePaidAmount(string id, decimal amount, string user)
        {
            string ClientName;

            string day = DateTime.Now.Day.ToString("D2"), month = DateTime.Now.Month.ToString("D2");

            string dateString = DateTime.Now.Year.ToString() + "-" + month + "-" + day;

            string getClientQuery = "select c_cl from ventes where n = '" + id + "';";

            string query = "update ventes set regler = case when totalttc <= montantregler+montantrest THEN 'Réglé' ELSE 'Non Réglé' END" +
                ",montantregler = montantregler + " + amount.ToString().Replace(",", ".") + " ," +
                " montantrest = (totalttc - ( montantregler +" +
                amount + ")), user = '" + user + "' where n = '" + id + "';";

            string update_expenses = "update [Caisse] set [entre] = entre+" + amount.ToString("F2")
               .Replace(",", ".") + ";";

            string add_to_Operations = "INSERT INTO [L_Caisse] ([Date],[Tiere],[N_Bon]," +
                "[Operation],[Entre],[Sortie],[User],[u_id]) values('" + dateString + "',@NomClient,'" + id
                + "','Dette'," + amount.ToString("F2").Replace(",", ".") + ",0,'" + user + "','"
                + Properties.Settings.Default.LoggedInUserID + "')";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteCommand getClient = new SQLiteCommand(getClientQuery, connection);
                SQLiteCommand UpdateExpenses = new SQLiteCommand(update_expenses, connection);
                SQLiteCommand AddToOps = new SQLiteCommand(add_to_Operations, connection);



                connection.Open();

                string ClientID = (getClient.ExecuteScalar() != DBNull.Value) ? getClient.ExecuteScalar().ToString() : "Non disponible";

                connection.Close();

                ClientName = GetClient(ClientID).Nom;

                AddToOps.Parameters.Add(new SQLiteParameter("@NomClient", ClientName));

                connection.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {

                    try
                    {
                        AddToOps.ExecuteNonQuery();
                        UpdateExpenses.ExecuteNonQuery();

                        connection.Close();

                        InsertIntoLog("Le client " + ClientName + " avec la référence " + ClientID + "  a payé " + amount.ToString() + " DA pour sa dette du facture N°: " + id);

                        return 1;

                    }
                    catch
                    {
                        connection.Close();
                        return 0;


                    }



                }
                else
                {
                    connection.Close();

                    return 0;
                }

            }
        }

        public int DeleteClient(string ClientID)
        {
            string query = "delete from client where c_cl = '" + ClientID + "';";
            string name = GetClient(ClientID).Nom;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();


                    ReplaceTheDeleted("ventes", ClientID);

                    InsertIntoLog("Le client " + ClientID + " sous le nom de " + name + " a été supprimé");


                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }


            }
        }
        public int DeleteSupplier(string ID)
        {
            string query = "delete from fourniseur where c_fr = '" + ID + "';";
            string name = GetSupplier(ID).Nom;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();


                    ReplaceTheDeleted("achat", ID);
                    InsertIntoLog("Le fournisseur " + ID + " sous le nom de " + name + " a été supprimé");

                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }


            }
        }

        public int ReplaceTheDeleted(string table, string id)
        {
            string column = (table == "achat") ? "c_fr" : "c_cl";
            bool purchase = table == "achat";

            string val = (table == "achat") ? "1" : "'X'";

            string updateBills = "update " + table + " set " + column + " = " + val + "  where " + column + " = '" + id + "';";

            string updateBillLines = "update ventes set c_cl = 'X' where c_cl = '" + id + "';";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(updateBills, connection);
                SQLiteCommand command1 = new SQLiteCommand(updateBillLines, connection);


                if (command.ExecuteNonQuery() > 0)
                {

                    if (!purchase)
                    {
                        if (command1.ExecuteNonQuery() > 0)
                        {
                            connection.Close();
                            return 1;
                        }
                        else
                        {
                            connection.Close();
                            return 0;
                        }
                    }

                    connection.Close();
                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }


            }



        }
        public int UpdatePurchasePaidAmount(string id, double amount, string user)
        {
            string SupplierName;

            string day = DateTime.Now.Day.ToString("D2"), month = DateTime.Now.Month.ToString("D2");

            string dateString = DateTime.Now.Year.ToString() + "-" + month + "-" + day;

            string getSupplierQuery = "select c_fr from achat where n = '" + id + "';";

            string query = "update achat set montantregler = montantregler + " + amount.ToString().Replace(",", ".") +
                " , montantrest = (totalttc - ( montantregler +" +
                amount.ToString().Replace(",", ".") + ")), user = '" + user + "'  where n = '" + id + "';";

            string update_expenses = "update [Caisse] set [sortie] = sortie+" + amount.ToString("F2")
   .Replace(",", ".") + ";";

            string add_to_Operations = "INSERT INTO [L_Caisse] ([Date],[Tiere],[N_Bon]," +
                "[Operation],[Entre],[Sortie],[User],[u_id]) values('" + dateString + "',@NomFour,'" + id
                + "','Dette',0," + amount.ToString("F2").Replace(",", ".") + ",'" + user + "','"
                + Properties.Settings.Default.LoggedInUserID + "')";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                SQLiteCommand getSupplier = new SQLiteCommand(getSupplierQuery, connection);
                SQLiteCommand UpdateExpenses = new SQLiteCommand(update_expenses, connection);
                SQLiteCommand AddToOps = new SQLiteCommand(add_to_Operations, connection);

                connection.Open();

                string SuppID = (getSupplier.ExecuteScalar() != DBNull.Value) ? getSupplier.ExecuteScalar().ToString() : "Non disponible";

                connection.Close();

                SupplierName = GetSupplier(SuppID).Nom;

                AddToOps.Parameters.Add(new SQLiteParameter("@NomFour", SupplierName));

                connection.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    try
                    {
                        AddToOps.ExecuteNonQuery();
                        UpdateExpenses.ExecuteNonQuery();

                        connection.Close();

                        InsertIntoLog("Vous avez payé " + SupplierName + " " + amount.ToString() + " DA pour votre dette du facture N°: " + id);

                        return 1;

                    }
                    catch
                    {
                        connection.Close();
                        return 0;
                    }

                }
                else
                {
                    connection.Close();

                    return 0;
                }

            }
        }
        public DataTable getSalesByClientID(string id, bool saved, bool ticket)
        {
            DataTable table = new DataTable();

            string query = "SELECT ventes.n,ventes.[Type],ventes.[DateA] as Date,Ventes.C_CL " +
                "as 'Ref client',client.Nom as 'Nom de client ',totalttc as " +
                    " Total, totalremise as 'Remise totale',ModeReglement as 'Mode reglement',Regler" +
                    " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                    " MontantRest as 'Montant reste'," +
                    " user FROM [Ventes] inner join client on client.c_cl = ventes.c_cl inner join l_ventes on l_ventes.n = ventes.n" +
               " where client.c_cl = '" + id + "' ";

            if (saved)
            {
                query += " and ventes.n like 'T%' ";
            }

            if (ticket)
            {
                query += " and ventes.n like '%B%' ";
            }
            else
            {
                query += " and ventes.n like '%F%' ";

            }

            query += " group by ventes.n;";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(table);

                connection.Close();

            }

            return table;


        }


        public DataTable searchForSales(string search, int selection)
        {


            DataTable table = new DataTable();

            string query = "SELECT ventes.n,ventes.[Type],ventes.[DateA] as Date,Ventes.C_CL as 'Ref client',client.Nom as 'Nom de client ',totalttc as " +
                " Total, totalremise as 'Remise totale',ModeReglement as 'Mode reglement',Regler" +
                " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                " MontantRest as 'Montant reste'," +
                " user FROM [Ventes] inner join client on client.c_cl = ventes.c_cl inner join l_ventes on l_ventes.n = ventes.n" +
           " where client.nom like '%" + search + "%' " +
           " or ventes.n like '%" + search + "%' or l_ventes.c_pr = (select c_prd from produits where nom like '%" + search + "%') order by Date desc ;";


            switch (selection)
            {

                case 5:

                    search = search.Replace("00:00:00", string.Empty).Trim();
                    string[] values = search.Split('-');

                    query = "SELECT n,[Type],[DateA] as Date,Ventes.C_CL as 'Ref client',client.Nom as 'Nom de client ',totalttc as " +
                "Total, totalremise as 'Remise totale',ModeReglement as 'Mode reglement',Regler" +
                " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                " MontantRest as 'Montant reste'," +
                " user FROM[Ventes] inner join client on client.c_cl = ventes.c_cl where" +
                " strftime('%Y',ventes.[DateA]) = '" + values[2].Trim() + "' and strftime('%m',ventes.[DateA]) = '" + values[1].Trim() + "' and strftime('%d',ventes.[DateA])= '" + values[0].Trim() + "' " +
                     "; ";

                    break;
                case 4:

                    query = "SELECT n,[Type],[DateA] as Date,Ventes.C_CL as 'Ref client',client.Nom as 'Nom de client ',totalttc as " +
                "Total, totalremise as 'Remise totale',ModeReglement as 'Mode reglement',Regler" +
                " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                " MontantRest as 'Montant reste'," +
                " user FROM[Ventes] inner join client on client.c_cl = ventes.c_cl where " +
          "ventes.type like '%" + search + "%' order by Date desc " +
         "; ";
                    break;

            }






            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(table);

                connection.Close();

            }

            return table;
        }

        public DataTable selectBillLines(string BillID)
        {

            DataTable table = new DataTable();

            string query = "select [N],[Type],[C_PR] as Réf,[Nomproduit] as Désignation ,[Quantité] as Qté,[PrixHT] as 'Prix U' " +
                ",[Marge],MontantHT as 'Montant HT',[Remise] from l_ventes where n ='" + BillID + "';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);

                connection.Close();

            }

            return table;
        }
        public DataTable selectPurchaseLines(string BillID)
        {

            DataTable table = new DataTable();

            string query = "select [N],[Type],[C_PR] as Réf,[Nomproduit] as Désignation ,[Quantité] as Qté,[PrixHT] as 'Prix U' " +
                ",MontantHT as 'Montant HT',[Remise] from l_achats where n ='" + BillID + "';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);

                connection.Close();

            }

            return table;
        }
        public Product selectProductByID(string str)
        {

            Product product = new Product();

            string query = "select [Nom],[Type],[Prix_VenteHT],[PrixVGros],[Q_Stock] from produits where C_Prd ='" + str.Trim() + "';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                SQLiteDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    product.PriceG = reader.GetDouble(3);
                    product.PriceD = reader.GetDouble(2);
                    product.Quantity = reader.GetDouble(4);
                    product.Name = reader.GetString(0);
                    product.Type = reader.GetString(1);

                }
                reader.Close();
                connection.Close();

            }

            return product;
        }
        public int DeleteBill(string iD)
        {
            string query = (iD != "all") ? "delete from ventes where n = '" + iD + "' ;" :
               "delete from ventes;";
            string query2 = "delete from l_ventes;";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteCommand salelinesCommand = new SQLiteCommand(query2, connection);

                if (iD == "all")
                {

                    if (salelinesCommand.ExecuteNonQuery() > 0)
                    {

                        if (command.ExecuteNonQuery() > 0)
                        {
                            connection.Close();

                            InsertIntoLog("Les rapports des ventes ont été supprimés");

                            return 1;
                        }
                        else
                        {
                            connection.Close();
                            return 0;
                        }
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }
                }
                else
                {
                    if (command.ExecuteNonQuery() > 0)
                    {

                        connection.Close();
                        InsertIntoLog("La ventes N°: " + iD + " a été supprimée ");

                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }
                }


            }
        }
        public int DeletePurchase(string iD)
        {
            string query = (iD != "all") ? "delete from achat where n = '" + iD + "' ;" :
                "delete from achat";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    if (iD != "all")
                    {
                        InsertIntoLog("L'achat N°: " + iD + " a été supprimé");

                    }
                    else
                    {
                        InsertIntoLog("Les rapports d'achat ont été supprimés");
                    }
                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }


            }
        }

        public int RemoveProductFromBill(double montant, string c_pr, string SaleID,
            bool returnProd, decimal quantity, bool modif)
        {
            string table = c_pr.Contains("FL") ? "emballage" : "produits";
            double SUM;

            string get_deletedSum = "select montantht from l_ventes where c_pr = '" + c_pr + "' and n = '" + SaleID + "' ;";

            string query1 = "delete from l_ventes where c_pr = '" + c_pr + "' and n = '" + SaleID + "' ;";

            string return_to_stock = "update " + table + " set q_stock = q_stock + " + quantity.ToString().Replace(",", ".") + "  where c_prd = '" + c_pr + "' ;";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                int val = 0;
                string query2 = "update ventes set totalttc = (select sum(quantité*prixht) from l_ventes where n= '" + SaleID + "')," +
                    " benefice = (select sum(marge) from l_ventes where n= '" + SaleID + "') where n='" + SaleID + "';";

                SQLiteCommand command = new SQLiteCommand(query1, connection);
                SQLiteCommand updateTotal = new SQLiteCommand(query2, connection);
                SQLiteCommand GetSUm = new SQLiteCommand(get_deletedSum, connection);
                SQLiteCommand getNewTotal = new SQLiteCommand("select totalttc from ventes where  n= '" + SaleID + "'", connection);


                if (returnProd)
                {

                    InsertIntoLog("Le produit: " + c_pr + " a été retourner au stock avec une quantité de:" + quantity + string.Empty);

                    connection.Open();

                    SUM = (GetSUm.ExecuteScalar() != null) ? double.Parse(GetSUm.ExecuteScalar().ToString()) : montant;


                    if (command.ExecuteNonQuery() > 0)
                    {
                        if (checkLength(SaleID) == 0 && !modif)
                        {
                            DeleteBill(SaleID);

                            if (!SaleID.Contains("T"))
                            {
                                if (new SQLiteCommand(return_to_stock, connection).ExecuteNonQuery() > 0)
                                {
                                    connection.Close();
                                    return -1;
                                }
                                else
                                {
                                    connection.Close();
                                    return 0;
                                }
                            }
                        }
                        else if (checkLength(SaleID) == 1 && !modif)
                        {
                            updateTotal.CommandText = "update ventes set totalttc = " +
                                "(select quantité * prixht from l_ventes where n = '"
                                + SaleID + "') where n = '" + SaleID + "'; ";
                        }

                        if (checkLength(SaleID) == 0 && modif)
                        {
                            updateTotal.CommandText = "update ventes set totalttc = 0 where n = '" + SaleID + "'; ";

                        }

                        if (updateTotal.ExecuteNonQuery() > 0)
                        {
                            if (!SaleID.Contains("T"))
                            {
                                updateTotal = new SQLiteCommand(return_to_stock, connection);

                                if (updateTotal.ExecuteNonQuery() > 0)
                                {

                                    new SQLiteCommand("update caisse set entre = entre - " + SUM + " ", connection).ExecuteNonQuery();


                                    SaleInfo.Total = (decimal)getNewTotal.ExecuteScalar();

                                    connection.Close();

                                    val = 1;
                                }
                                else
                                {
                                    connection.Close();
                                    val = 0;
                                }
                            }
                            else
                            {
                                SaleInfo.Total = (decimal)getNewTotal.ExecuteScalar();

                                connection.Close();

                                val = 1;
                            }

                        }
                        else
                        {

                            connection.Close();
                            val = 0;
                        }


                    }
                    else
                    {
                        connection.Close();
                        val = 0;
                    }
                }
                else
                {
                    InsertIntoLog("Le produit: " + c_pr + " a été supprimer de la vente N°:" + SaleID + " avec une quantité de:" + quantity + string.Empty);

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {

                        if (checkLength(SaleID) == 0)
                        {
                            DeleteBill(SaleID);
                            return -1;
                        }
                        else if (checkLength(SaleID) == 1)
                        {
                            updateTotal.CommandText = "update ventes set totalttc = " +
                                "(select quantité * prixht from l_ventes where n = '"
                                + SaleID + "') where n = '" + SaleID + "'; ";
                        }
                        if (updateTotal.ExecuteNonQuery() > 0)
                        {

                            SaleInfo.Total = (decimal)getNewTotal.ExecuteScalar();
                            connection.Close();

                            val = 1;

                        }
                        else
                        { val = 0; }


                    }
                    else
                    {
                        connection.Close();
                        val = 0;
                    }
                }

                return val;

            }
        }

        public double checkProdQT(string c_pr)
        {
            string check_qt = "select q_stock from produits where c_prd = '" + c_pr + "' ;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand checkQT = new SQLiteCommand(check_qt, connection);

                connection.Open();
                if (double.Parse(checkQT.ExecuteScalar().ToString()) == 0)
                {
                    connection.Close();
                    return 0;
                }
                else
                {
                    connection.Close();
                    return 1;
                }
            }

        }
        public int RemoveProductFromPurchase(string iD, string SaleID, bool returnProd, string c_pr, decimal quantity)
        {
            double SUM;
            string get_deletedSum = "select montantht from l_achats where c_pr = '" + iD + "' and n = '" + SaleID + "';";


            string query1 = "delete from l_achats where c_pr = '" + iD + "' and n = '" + SaleID + "' ;";

            string return_to_stock = "update produits set q_stock = q_stock-" + quantity + "  where c_prd = '" + c_pr + "' ;";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                int val = 0;
                string query2 = "update achat set totalttc = (select sum(quantité*prixht) from l_achats where n= '" + SaleID + "') where n='" + SaleID + "';";

                SQLiteCommand command = new SQLiteCommand(query1, connection);
                SQLiteCommand updateTotal = new SQLiteCommand(query2, connection);
                SQLiteCommand GetSum = new SQLiteCommand(get_deletedSum, connection);
                SQLiteCommand getNewTotal = new SQLiteCommand("select totalttc from ventes where  n= '" + SaleID + "'", connection);

                if (returnProd)
                {

                    InsertIntoLog("Le produit: " + iD + " a été retiré du stock avec une quantité de:" + quantity + string.Empty);

                    connection.Open();

                    SUM = double.Parse(GetSum.ExecuteScalar().ToString());


                    new SQLiteCommand("update caisse set sortie = sortie - " + SUM + string.Empty, connection).ExecuteNonQuery();


                    if (command.ExecuteNonQuery() > 0)
                    {
                        if (checkLength(SaleID) == 0)
                        {
                            DeletePurchase(SaleID);

                            if (new SQLiteCommand(return_to_stock, connection).ExecuteNonQuery() > 0)
                            {
                                connection.Close();
                                return -1;
                            }
                            else
                            {
                                connection.Close();
                                return 0;
                            }

                        }
                        else if (checkLength(SaleID) == 1)
                        {
                            updateTotal.CommandText = "update achat set totalttc = " +
                                "(select quantité * prixht from l_achats where n = '"
                                + SaleID + "') where n = '" + SaleID + "'; ";
                        }

                        if (updateTotal.ExecuteNonQuery() > 0)
                        {
                            updateTotal = new SQLiteCommand(return_to_stock, connection);

                            if (updateTotal.ExecuteNonQuery() > 0)
                            {
                                new SQLiteCommand("update caisse set sortie = sortie - " + SUM + string.Empty, connection).ExecuteNonQuery();

                                PurchaseInfo.Total = (decimal)getNewTotal.ExecuteScalar();

                                connection.Close();

                                val = 1;
                            }
                            else
                            {
                                connection.Close(); val = 0;
                            }




                        }


                    }
                    else
                    {
                        connection.Close();
                        val = 0;
                    }
                }
                else
                {
                    InsertIntoLog("Le produit: " + iD + " a été supprimer de l'achat N°:" + SaleID + " avec une quantité de:" + quantity + string.Empty);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {

                        if (checkLength(SaleID) == 0)
                        {
                            DeletePurchase(SaleID);
                            return -1;
                        }
                        else if (checkLength(SaleID) == 1)
                        {
                            updateTotal.CommandText = "update achat set totalttc = " +
                               "(select quantité * prixht from l_achats where n = '"
                               + SaleID + "') where n = '" + SaleID + "'; ";
                        }
                        if (updateTotal.ExecuteNonQuery() > 0)
                        {

                            SaleInfo.Total = (decimal)getNewTotal.ExecuteScalar();
                            connection.Close();

                            val = 1;

                        }
                        else
                        { val = 0; }


                    }
                    else
                    {
                        connection.Close();
                        val = 0;
                    }
                }

                return val;

            }
        }

        public int checkLength(string SaleID)
        {
            int length = 0;
            string checklength = "select count(n) from l_ventes where n = '" + SaleID + "' ;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkL = new SQLiteCommand(checklength, connection);



                SQLiteDataReader reader = checkL.ExecuteReader();

                if (reader.Read())
                {

                    length = reader.GetInt32(0);
                }



                reader.Close();
                connection.Close();

            }
            return length;

        }


        public DataTable selectPurchases(int limit, int currentPage)
        {
            string query = "SELECT n as Réf,[Type],[DateA] as Date,achat.c_fr as 'Reference de fournisseur'," +
            "fourniseur.Nom 'Nom de fournisseur',totalttc as " +
               "Total,ModeReglement,Regler" +
               " as 'Reglée',MontantRegler as 'Montant Réglé'," +
               " MontantRest as 'Montant reste'," +
               " user FROM [Achat] inner join fourniseur on fourniseur.c_fr = achat.c_fr order by Date" +
               " desc limit " + limit + " offset " + (currentPage - 1) * limit + ";";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);



                connection.Close();
                return table;

            }
        }

        public static string generateID(string prefix, Tables table)
        {
            string id = prefix;
            string tableName = table.ToString();
            string replace = string.Empty;
            string offset = "D7";
            switch (table)
            {

                case Tables.L_ventes:

                    if (prefix == "BL")
                    {
                        replace = "replace(n,'BL','') ";

                    }
                    else
                        replace = "replace(n,'FA','') ";


                    break;
                case Tables.ventes:

                    if (prefix == "BL")
                    {
                        replace = "replace(n,'BL','') ";

                    }
                    else
                        replace = "replace(n,'FA','') ";


                    break;
                case Tables.Fourniseur:
                    replace = "replace(c_fr,'FR','') ";

                    break;
                case Tables.Client:
                    replace = "replace(c_cl,'CL','') ";

                    break;
                case Tables.produits:
                    replace = "replace(c_prd,'PR','') ";
                    offset = "D4";
                    break;

                case Tables.user:
                    replace = "replace(n,'US','') ";
                    offset = "D4";
                    break;
                case Tables.ventesTemp:

                    if (prefix == "TBL")
                    {
                        replace = "replace(n,'TBL','') ";

                    }
                    else
                        replace = "replace(n,'TFA','') ";


                    break;
                case Tables.emballage:
                    replace = "replace(c_prd,'FL','') ";
                    offset = "D4";
                    break;
            }


            string query = string.Empty;
            if (replace != string.Empty)
            {
                query = "select max(cast( " + replace + " AS INTEGER))  from " + tableName.Replace("Temp", string.Empty) + ";";

            }
            else
            {

                query = "select max(n)  from " + tableName + ";";

            }

            if (tableName == Tables.Decaissement.ToString() ||
                tableName == Tables.Encaissement.ToString())
            {


                string columnName = (tableName.StartsWith("E")) ? tableName.Substring(0, 2) :
                    tableName.Substring(0, 3);


                query = "select max(cast(replace(n_" + columnName + ",'" +
                    tableName.Substring(0, 3).ToUpper() + "','') AS INTEGER))  from " +
                        tableName + ";";
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);
                connection.Open();
                object va = command.ExecuteScalar();
                string maxID = (va != DBNull.Value) ? va.ToString() : "0";
                id += (int.Parse(maxID) + 1).ToString(offset);
                connection.Close();

            }


            return id;
        }


        public bool ProductExists(string id)
        {
            string table = (!id.Contains("FL")) ? "produits" : "emballage";
            string checklength = "select count(c_prd) from " + table + " where c_prd = '" + id + "' ;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkL = new SQLiteCommand(checklength, connection);




                if (int.Parse(checkL.ExecuteScalar().ToString()) > 0)
                {

                    connection.Close();

                    return true;
                }
                else
                {

                    connection.Close();
                    return false;

                }




            }
        }
        public double SelectLastPurchaseTotal()
        {
            double amount = 0;

            string checkTotal = "select sum(totalTTC) from achat  WHERE datea >= DATE('now', '-7 days'); ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkT = new SQLiteCommand(checkTotal, connection);
                SQLiteDataReader reader = checkT.ExecuteReader();



                if (reader.Read())
                {

                    amount = (reader.GetValue(0) != DBNull.Value) ? reader.GetDouble(0) : 0;
                    reader.Close();
                    connection.Close();

                    return amount;

                }
                else
                {

                    reader.Close();
                    connection.Close();
                    return -1;
                }




            }


        }
        public int AddProduct(Product product, double Quantity)
        {
            string dateString = DateTime.Now.ToString("yyyy-MM-dd");

            string table = (product.ID.Contains("FL") ? "emballage" : "produits");

            string checklength = "insert into " + table + "  (C_prd , nom,type, prix_achat,prix_venteht," +
                "prixvgros,unit,q_stock,c_bare,stock_alerte,c_fr,dateajout) values('" +
                product.ID + "','" + product.Name.Replace("'", "''") + "','" + product.Type + "', "
                + product.PriceP.ToString(nfi)
                + "," + product.PriceD.ToString(nfi) + "," + product.PriceG.ToString(nfi) + ",'"
                + product.Unit + "', " + Quantity.ToString(nfi) + ",'" + product.BarCode + "'," + product.StockAlert.ToString(nfi) + "," +
                "'" + product.c_fr + "','" + dateString + "' );";

            InsertIntoLog("Le produit: " + product.ID + " a été ajouté");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkL = new SQLiteCommand(checklength, connection);


                if (checkL.ExecuteNonQuery() > 0)
                {
                    connection.Close();

                    return 1;

                }
                else
                {
                    connection.Close();
                    return 0;
                }





            }

        }
        public int EditProduct(Product product, double quantity)
        {

            string table = (product.ID.Contains("FL")) ? "emballage" : "produits";

            string update_product = "update " + table + " set nom = @NAME,prix_achat = @prix_achat," +
                "unit = @unit ,q_stock = q_stock+@quantity, stock_alerte = @sa , c_fr = @c_fr" +
                "  where c_prd = @id ;";

            SQLiteParameter parameter = new SQLiteParameter("@NAME", product.Name.Replace("'", "''")),
                 parameter1 = new SQLiteParameter("@prix_achat", product.PriceP.ToString(nfi)),
                  parameter2 = new SQLiteParameter("@unit", product.Unit),
                   parameter3 = new SQLiteParameter("@quantity", quantity.ToString(nfi)),
                   param = new SQLiteParameter("@sa", product.StockAlert.ToString(nfi)),
                   param5 = new SQLiteParameter("@c_fr", product.c_fr),
                        parameter4 = new SQLiteParameter("@id", product.ID);


            SQLiteParameter[] parameters = new SQLiteParameter[] { parameter, parameter1, parameter2, parameter3, parameter4, param, param5 };

            InsertIntoLog("Le produit: " + product.ID + " a été modifié ");


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkL = new SQLiteCommand(update_product, connection);
                checkL.Parameters.AddRange(parameters);



                if (checkL.ExecuteNonQuery() > 0)
                {
                    connection.Close();

                    return 1;
                }
                else
                {
                    connection.Close();

                    return 0;
                }





            }

        }
        public int AddPurchaseLines(PurchaseLine purchaseLine, Product product)
        {
            string insertAchatLine;


            string date = purchaseLine.DateA.Date.Year + "-" +
                purchaseLine.DateA.Date.Month.ToString("D2") + "-" +
                purchaseLine.DateA.Date.Day.ToString("D2");






            insertAchatLine = "insert into l_Achats ([N], [Type], [DateA]" +
             ",c_pr,[nomproduit],[quantité]," +
             "[prixht],[remise],montantht) " +
             "values('" + purchaseLine.N + "','" + purchaseLine.Type.Trim() +
             "','" + date + "','" + product.ID +
             "','" + purchaseLine.Nomproduit.Replace("'", "''") + "'," + purchaseLine.Quantité.ToString(nfi) + ","
             + purchaseLine.PrixHT.ToString(nfi) +
                "," + purchaseLine.Remise.ToString(nfi) + "," + purchaseLine.MontantHT.ToString(nfi) + ");";

            if (ProductExists(product.ID))
            {

                UpateStockPurchase(product);
                EditProduct(product, purchaseLine.Quantité);
            }
            else
            {

                AddProductToStock(product, purchaseLine.Quantité);

                AddProduct(product, purchaseLine.Quantité);

            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(insertAchatLine, connection))
                {
                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }

                }
            }




        }

        private bool UpateStockPurchase(Product product)
        {
            string add_to_Operations = "update [Stock] set [NomProduit] = '" + product.Name.Replace("'", "''")
                + "',[PrixVente] = " + product.PriceD.ToString(nfi) + " " +
                ",[Entre] = entre+" + product.Quantity.ToString(nfi) +
                ",[PrixAchat] = " + product.PriceP.ToString(nfi) /*+
                    ",[MontantAchat] = " + (product.Quantity * product.PriceP).ToString(nfi) + ","*/
                + ",[codeBarre] = '" + product.BarCode + "' where code = '" + product.ID + "' ;";

            bool done = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand operations = new SQLiteCommand(add_to_Operations, connection))
                {
                    connection.Open();

                    if (operations.ExecuteNonQuery() > 0)
                    {

                        done = true;

                    }

                    connection.Close();
                }


                return done;
            }

        }
        public bool AddProductToStock(Product product, double quantity)
        {
            string add_to_STOCK = "INSERT INTO [Stock] ([Code],[NomProduit],[PrixVente]" +
                ",[Entre],[Sortie],[PrixAchat],[codeBarre])" +
                "values('" + product.ID + "','" + product.Name.Replace("'", "''") + "'," + product.PriceD.ToString(nfi) + "," + quantity.ToString(nfi) + ",0,"
                + product.PriceP.ToString(nfi) + ",'" + product.BarCode + "')";

            bool done = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand operations = new SQLiteCommand(add_to_STOCK, connection))
                {
                    connection.Open();

                    if (operations.ExecuteNonQuery() > 0)
                    {

                        done = true;

                    }

                    connection.Close();
                }


                return done;
            }

        }


        public int AddPurchase(List<PurchaseLine> purchases,
            double total, string reglé, double montantRegler,
            float tva, List<Product> products, bool spend)
        {


            string ID = generateID(string.Empty, Tables.Achat);
            string insertIntoAchat = "insert into Achat ([N],[Type],[DateA],[C_FR],[TotalTTC]" +
                ",[ModeReglement],[Regler]," +
                "[MontantRegler],[MontantRest],[TauxTVA],user) values(@ID,@type,@date,@c_fr,@total," +
                "@modeReglement,@regler,@mregler,@mreste,@tva, @user);";

            InsertIntoLog("Un achat avec la référence: " + ID + " a été effectuée avec un total de: " + total + " DA, versement de: " + montantRegler + " DA");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                SQLiteCommand achatCommand = new SQLiteCommand(insertIntoAchat, connection);

                string c_fr = string.Empty;
                if (purchases[0].C_FR == null)
                {

                    if (string.IsNullOrEmpty(purchases[0].NomFour) ||
                        purchases[0].NomFour == "Nom de fournisseur...")
                    {
                        c_fr = "1";
                    }
                    else
                    {
                        c_fr = generateID("FR", Tables.Fourniseur);
                        Supplier supplier = new Supplier(c_fr, purchases[0].NomFour);

                        if (!InsertSupplier(supplier))
                        {
                            return -1;
                        }
                    }

                }
                else
                {
                    c_fr = purchases[0].C_FR;
                }


                SaleLine s = new SaleLine();
                s.N = purchases[0].N;
                s.Type = "Achat";

                for (int i = 0; i < purchases.Count; i++)
                {
                    purchases[i].N = ID;
                    s.Nomproduit = purchases[i].Nomproduit;
                    s.PrixHT = purchases[i].PrixHT;
                    s.Quantité = purchases[i].Quantité;
                    s.C_PR = products[i].ID;

                    AddPurchaseLines(purchases[i], products[i]);
                    InsertIntoStockHistory(s, c_fr);


                }
                string date = purchases[0].DateA.Date.Year + "-" + purchases[0].DateA.Date.Month.ToString("D2") + "-" + purchases[0].DateA.Date.Day.ToString("D2");
                SQLiteParameter sQLiteParameter = new SQLiteParameter("@ID", ID),
                                sQLiteParameter1 = new SQLiteParameter("@type", "Bon"),
                                sQLiteParameter2 = new SQLiteParameter("@date", date),
                                sQLiteParameter3 = new SQLiteParameter("@c_fr", c_fr),
                                sQLiteParameter4 = new SQLiteParameter("@total", total.ToString().Replace(",", ".")),
                                sQLiteParameter5 = new SQLiteParameter("@modeReglement", "Cash"),
                                sQLiteParameter6 = new SQLiteParameter("@regler", reglé),
                                sQLiteParameter7 = new SQLiteParameter("@mregler", montantRegler.ToString().Replace(",", ".")),
                                sQLiteParameterU = new SQLiteParameter("@user", Properties.Settings.Default.LoggedInUserID + "(" + Properties.Settings.Default.LoggedInUserName + ")"),

                                sQLiteParameter8 = new SQLiteParameter("@mreste", Math.Round(total - montantRegler, 2).ToString().Replace(",", ".")),
                                sQLiteParameter9 = new SQLiteParameter("@tva", (total * tva) / 100);
                SQLiteParameter[] paramms = new SQLiteParameter[] { sQLiteParameter,
                    sQLiteParameter1, sQLiteParameter2,sQLiteParameter3,sQLiteParameter4,sQLiteParameter5,sQLiteParameter6
                ,sQLiteParameter7,sQLiteParameter8,sQLiteParameter9,sQLiteParameterU};

                achatCommand.Parameters.AddRange(paramms);

                connection.Open();

                if (achatCommand.ExecuteNonQuery() > 0)
                {
                    if (spend)
                    {
                        Spend(Math.Round(montantRegler, 2), date, purchases[0].NomFour == "Nom de fournisseur..."
                            ? "Non disponible" : purchases[0].NomFour, purchases[0].N, "Achat", 0);

                    }

                    connection.Close();
                    return 1;
                }
                else
                {
                    connection.Close();
                    return -1;
                }







            }

        }
        public bool Spend(double total, string date, string nomfour, string ID, string Op, double Entry)
        {
            string update_expenses = "update [Caisse] set [sortie] = sortie+" + total.ToString().Replace(",", ".") + ";";

            string add_to_Operations = "INSERT INTO [L_Caisse] ([Date],[Tiere],[N_Bon]," +
                "[Operation],[Entre],[Sortie],[User],[u_id]) values('" + date + "','" + nomfour + "','" + ID + "','" + Op +
                "'," + Entry + "," + total.ToString().Replace(",", ".") + ",'" + Properties.Settings.Default.LoggedInUserName + "','" + Properties.Settings.Default.LoggedInUserID + "')";


            bool done = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand expenses = new SQLiteCommand(update_expenses, connection)
                    , operations = new SQLiteCommand(add_to_Operations, connection);

                connection.Open();
                if (expenses.ExecuteNonQuery() > 0)
                {
                    if (operations.ExecuteNonQuery() > 0)
                    {

                        done = true;

                    }
                }


                connection.Close();
                return done;
            }
        }


        public AutoCompleteStringCollection searchForIDs(string table, string text)
        {
            AutoCompleteStringCollection refs = new AutoCompleteStringCollection();

            string search = "select c_prd from " + table + " where c_prd like '%" + text + "%' limit 10 ;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand com = new SQLiteCommand(search, connection))
                {

                    using (SQLiteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            refs.Add(reader.GetString(0));
                        }
                        reader.Close();

                    }
                    connection.Close();

                }

            }

            return refs;
        }

        #region DISPOSABLE Methods
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DBHelper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
        public Product GetProductByID(string table, string selection)
        {

            Product product = new Product();
            string query = "select  " + table + ".nom,type, prix_achat,prix_venteht,prixvgros,unit,c_prd,q_stock," +
            " stock_alerte," + table + ".c_fr,fourniseur.nom from " + table + " inner join fourniseur on fourniseur.c_fr = " + table + ".c_fr " +
            "where c_prd = '" + selection + "';";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product.Name = reader.GetString(0);
                            product.Type = reader.GetString(1);
                            product.PriceP = reader.GetDouble(2);
                            product.PriceD = reader.GetDouble(3);
                            product.PriceG = reader.GetDouble(4);
                            product.Unit = reader.GetString(5);
                            product.ID = reader.GetString(6);
                            product.Quantity = reader.GetDouble(7);
                            product.StockAlert = reader.GetDouble(8);
                            product.c_fr = reader.GetString(9);
                            product.SupplierName = reader.GetString(10);


                        }
                        reader.Close();
                        connection.Close();
                    }
                }


                return product;
            }
        }
        public string getStoreBarCode()
        {
            string query = "select  substr(codebarre,0,4) from information;";
            string barcode;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();
                    barcode = (string)command.ExecuteScalar();
                    connection.Close();
                }
            }
            return barcode;
        }

        public AutoCompleteStringCollection GetSupplierNames(string name, out Dictionary<string, string> supps)
        {
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            string query = "SELECT nom,c_fr FROM fourniseur WHERE nom LIKE @name;";
            supps = new Dictionary<string, string>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");

                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add(reader.GetString(0));
                            supps.Add(reader.GetString(1), reader.GetString(0));
                        }
                    }
                }
                connection.Close();
            }

            return names;
        }

        public DataTable searchForPurchases(string search, int selection)
        {



            string query = "SELECT achat.n,achat.[Type],achat.[DateA] as Date,achat.c_fr as 'Reference de fournisseur', fourniseur.Nom as 'Nom de fournisseur',totalttc as " +
                "Total,ModeReglement,Regler" +
                " as 'Reglée',MontantRegler as 'Montant Réglé'," +
                " MontantRest as 'Montant reste'," +
                " user FROM [Achat] inner join fourniseur on fourniseur.c_fr = achat.c_fr  inner join l_achats on l_achats.n = achat.n  "
                + "  where (select c_prd from produits where nom   like '%" + search + "%' limit 1) = l_achats.c_pr or fourniseur.Nom " +
                " like '%" + search + "%' or c_pr like '%" + search + "%' or achat.n  like '%" + search + "%';";

            switch (selection)
            {

                case 4:

                    search = search.Replace("00:00:00", string.Empty).Trim();
                    string[] values = search.Split('-');

                    query = "SELECT achat.n,achat.[Type],achat.[DateA] as Date, achat.c_fr as 'Reference de fournisseur', fourniseur.Nom as 'Nom de fournisseur',totalttc as " +
             "Total,ModeReglement,Regler" +
             " as 'Reglée',MontantRegler as 'Montant Réglé'," +
             " MontantRest as 'Montant reste'," +
             " user FROM [Achat] inner join fourniseur on fourniseur.c_fr = achat.c_fr where strftime('%Y',achat.[DateA]) = '"
             + values[2].Trim() + "' and strftime('%m',achat.[DateA]) = '" + values[1].Trim() +
             "' and strftime('%d',achat.[DateA])= '" + values[0].Trim() + "' ;";

                    break;

            }



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);



                connection.Close();
                return table;

            }
        }
        public Supplier getSupplierInfo(string str)
        {
            Supplier supplier = new Supplier();

            string query = "select nom, tel,activite, email,adresse  from fourniseur where c_fr = '" + str + "';";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    supplier.Nom = reader.GetString(0);

                    if (reader.GetValue(1) != null)
                    {
                        try
                        {
                            supplier.Tel = (string)reader.GetValue(1);

                        }
                        catch
                        {
                            supplier.Tel = "Non disponible";
                        }
                    }

                    if (reader.GetValue(2) != null)
                    {
                        try
                        {
                            supplier.Activite = (string)reader.GetValue(2);
                        }
                        catch
                        {
                            supplier.Activite = "Non disponible";
                        }
                    }

                    if (reader.GetValue(3) != null)
                    {
                        try
                        {
                            supplier.Email = (string)reader.GetValue(3);

                        }
                        catch
                        {
                            supplier.Email = "Non disponible";
                        }
                    }
                    if (reader.GetValue(4) != null)
                    {
                        try
                        {
                            supplier.Adresse = (string)reader.GetValue(4);

                        }
                        catch
                        {
                            supplier.Adresse = "Non disponible";
                        }
                    }

                }

                reader.Close();
                connection.Close();
            }

            return supplier;
        }
        public string[] GetSavingAccount(string iD)
        {
            string[] motifAndAmount = new string[2] { "Non disponible", "Non disponible" };
            string query = "select nom, amount from ComptesEpargnes where id = " + iD + ";";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            motifAndAmount[0] = (reader.GetValue(0) != DBNull.Value) ? reader.GetString(0) : "Non disponible";
                            motifAndAmount[1] = (reader.GetValue(1) != DBNull.Value) ? reader.GetDouble(1).ToString() : "Non disponible";


                        }
                    }

                }
                connection.Close();
            }

            return motifAndAmount;

        }
        public void RemoveAccount(string iD)
        {
            string query = "delete from ComptesEpargnes where id = " + iD + ";";
            string[] compte = GetSavingAccount(iD);

            InsertIntoLog("Le compte d'épargne sous le nom de: " + compte[0] + " et le montant de: " + compte[1] + " a été supprimé");


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

        }
        public static DataTable GetSavingAccounts()
        {
            string query = "select id as ID,Nom as Nom,amount as Montant from ComptesEpargnes;";
            DataTable item = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(item);
                }


                connection.Close();

            }

            return item;
        }
        public void AddAccount(AccountItemModel model)
        {
            string query = "insert into ComptesEpargnes(nom,amount) values('" + model.Name + "'," + model.Amount + ");";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            InsertIntoLog("Un compte d'épargne sous le nom de: " + model.Name + " et le montant de: " + model.Amount + " a été ajouté");


        }
        public void EditAccount(double amount, string iD)
        {
            string query = "update ComptesEpargnes set amount = " + amount.ToString().Replace(",", ".") + " where id = " + iD + ";";
            string[] compte = GetSavingAccount(iD);

            InsertIntoLog("Le montant d'un compte d'épargne sous le nom de: " + compte[0] + " a été remplacé par: " + amount.ToString().Replace(",", "."));


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public DataTable selectRegisterLines(int limit, int currentPage)
        {
            string query = "SELECT  Date, Tiere, n_bon as 'Ref de bon', Operation as 'Opération', entre as Entrée, Sortie  " +
                "from l_caisse order by date desc limit " + limit + " offset " + (currentPage - 1) * limit + ";";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);



                connection.Close();
                return table;

            }
        }

        internal DataTable searchForOps(string v, int selection, int limit, int currentPage)
        {

            string query = "SELECT  Date, Tiere, n_bon as 'Ref de bon', Operation as 'Opération'," +
                        " entre as Entrée, Sortie  from l_caisse where Tiere like '%" + v + "%' or n_bon like '%" + v + "%' order by date desc limit "
                        + limit + " offset " + (currentPage - 1) * limit + ";";

            switch (selection)
            {
                case 0:

                    query = "SELECT  Date, Tiere, n_bon as 'Ref de bon', Operation as 'Opération'," +
                        " entre as Entrée, Sortie  from l_caisse where Operation = '" + v + "' order by date desc " +
                        " limit " + limit + " offset " + (currentPage - 1) * limit + ";";
                    break;
                case 2:
                    v = v.Replace("00:00:00", string.Empty).Trim();
                    string[] values = v.Split('-');

                    query = "SELECT  Date, Tiere, n_bon as 'Ref de bon', Operation as 'Opération'," +
                        " entre as Entrée, Sortie  from l_caisse where strftime('%Y',Date) = '" +
                        values[2].Trim() + "' and strftime('%m',[Date]) = '" +
                        values[1].Trim() + "' and strftime('%d',[Date])= '" + values[0].Trim() + "'   order by date desc limit " +
                        limit + " offset " + (currentPage - 1) * limit + ";";
                    break;


            }



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);



                connection.Close();
                return table;

            }
        }
        public double[] GetEarningsAndExpenses()
        {

            double[] values = new double[2];
            string query = "SELECT  entre, sortie from  caisse; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {


                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            values[0] = reader.GetDouble(0);
                            values[1] = reader.GetDouble(1);

                        }

                        reader.Close();

                    }

                }
                connection.Close();
            }

            return values;

        }

        public double GetCapital()
        {
            double capital = 0;
            string query = "SELECT  capital from (select sum(prix_achat*q_stock) as capital from produits)  ; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {


                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            capital = reader.GetDouble(0);


                        }

                        reader.Close();

                    }

                }
                connection.Close();
            }

            return capital;

        }

        public int Caisser(string op, string motif, string amount)
        {
            string id = generateID((op == "Décaisser") ? "DEC" : "ENC",
                (op == "Décaisser") ? Tables.Decaissement : Tables.Encaissement);
            string day = DateTime.Now.Day.ToString("D2"), month = DateTime.Now.Month.ToString("D2");

            string dateString = DateTime.Now.Year.ToString() + "-" + month + "-" + day;

            string query = (op == "Décaisser") ? "insert into decaissement ([N_Dec],[Date],[User],[Motif],[Somme])" +
                " values('" + id + "','" + dateString + "','" + Properties.Settings.Default.LoggedInUserName + "','" + motif + "'," + amount + ");" :
                "insert into encaissement ([N_En],[Date],[User],[Motif],[Somme])values('" + id +
                "','" + dateString + "','" + Properties.Settings.Default.LoggedInUserName + "','" + motif + "'," + amount + ");";
            string caissQuery = (op == "Décaisser") ? "update caisse set sortie = sortie+" + amount + ";" : "update caisse set entre = entre+" + amount + ";";
            string logtext = (op == "Décaisser") ? "décaissement" : "encaissement";
            InsertIntoLog("Un " + logtext + " de " + amount + " DA sous le motif de: " + motif + " a été effectué");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        command.CommandText = caissQuery;

                        if (command.ExecuteNonQuery() > 0)
                        {
                            connection.Close();

                            return 1;
                        }
                        else
                        {
                            connection.Close();

                            return 0;
                        }

                    }
                    else
                    {
                        connection.Close();

                        return 0;
                    }
                }
            }
        }
        public DataTable GetClients(int limit, int currentPage)
        {
            string query = "select c_cl as Réf,nom,tel,activite,adresse,Datajout as 'Date d''ajout' from client limit " + limit + " offset (" + limit + "* " + (currentPage - 1) + ");";
            DataTable table = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }



                connection.Close();

            }

            return table;
        }
        public int GetClientsNumber()
        {
            string query = "select count(c_cl) from client ;";
            int number = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    number = Convert.ToInt32(command.ExecuteScalar());

                }
                connection.Close();
            }

            return number;
        }
        public DataTable searchClients(string search, bool WithDebts)
        {
            string query = (!WithDebts) ? "select c_cl as Réf,Nom,Tel,Activite as Activité ,Adresse ,Datajout as 'Date d''ajout' " +
                " from client where Nom like '%" + search + "%' or c_cl like '%" + search + "%';" :
                "select ventes.n as 'Réf Bon', datea as Date,client.c_cl as Réf,Nom,Tel,totalttc as Total," +
                "montantrest as 'Montant reste' " +
                " from client inner join ventes on client.c_cl = ventes.c_cl where (client.Nom like '%" + search + "%' or client.c_cl like '%" + search + "%') and montantrest > 0;";


            DataTable table = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }



                connection.Close();

            }

            return table;
        }

        public double GetTotalClientPurchases(string ID)
        {
            double amount = 0;
            string query = "select sum (quantité*prixht) from l_ventes where c_cl = '" + ID + "';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    try
                    {
                        amount = Convert.ToDouble(command.ExecuteScalar());

                    }
                    catch (Exception)
                    {

                        amount = 0;
                    }
                }
                connection.Close();
            }

            return amount;
        }
        public double GetTotalClientDebt(string ID)
        {
            double amount = 0;
            string query = "select  sum(montantrest) FROM ventes where ventes.c_cl =  '" + ID + "';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    try
                    {
                        amount = Convert.ToDouble(command.ExecuteScalar());

                    }
                    catch (Exception)
                    {

                        amount = 0;
                    }
                }
                connection.Close();
            }

            return amount;
        }
        public int GetDebtsNumber(string table)
        {
            int count = 0;


            string query = (table == "v") ? "SELECT COUNT(c_cl) from ventes where montantrest > 0 ; " :
                "SELECT COUNT(c_fr) from achat where montantrest > 0 ; ";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                connection.Close();
            }

            return count;
        }

        public string[] GetOldestDebtDate(bool clientDebt)
        {
            string[] date = new string[2];

            string query = clientDebt ?
                "SELECT min(datea) as Date,Nom from client inner join ventes on client.c_cl = ventes.c_cl where montantrest > 0 ;" :
                "SELECT min(datea) as Date,Nom from fourniseur inner join achat on achat.c_fr = fourniseur.c_fr where montantrest > 0 ;";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            date[0] = reader.GetString(0);
                            date[1] = reader.GetString(1);

                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }

            return date;
        }
        public DataTable GetLoyalClients()
        {
            DataTable table = new DataTable();

            string query = "WITH customer_clv AS ( SELECT   ventes.c_cl as client_id,	nom,   SUM(TotalTTC) AS total_spent," +
                "   COUNT(DISTINCT n) AS total_transactions,   MAX(DateA) AS last_transaction_date,   (JULIANDAY(MAX(DateA)) - JULIANDAY(MIN(DateA))) " +
                "AS days_active FROM ventes inner join client on client.c_cl = ventes.c_cl GROUP BY client_id), loyalty " +
                " AS (SELECT  client_id,nom, total_spent,total_transactions, last_transaction_date,days_active,CASE  WHEN days_active <= 30 THEN 'Actif' WHEN " +
                "days_active <= 90 THEN 'Normal' ELSE 'En perte' END AS loyalty_status FROM customer_clv) SELECT   l.client_id as Réf,l.nom, l.total_spent as 'Total des achats', l.total_transactions as 'Nombre de transactions'," +
                " l.last_transaction_date 'Dernière transaction', l.days_active 'Jours actif', l.loyalty_status 'Etat de fidélité', case when l.days_active = 0 then 0 else (l.total_spent / l.days_active) end AS CLV_par_jour FROM loyalty l order by CLV_par_jour desc ;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                    connection.Close();
                }

            }

            return table;
        }
        public DataTable GetDebts(bool clientDebt, int limit, int currentPage)
        {
            string query = clientDebt ? "select ventes.n as 'Réf Bon',datea as Date,client.c_cl as Réf,Nom,Tel,totalttc as Total," +
                "montantrest as 'Montant reste' from client  inner join ventes on client.c_cl = ventes.c_cl where montantrest > 0  limit " + limit
                + " offset (" + limit + "* " + (currentPage - 1) + ");" :
                "select achat.n as 'Réf Bon',datea as Date,fourniseur.c_fr as Réf,Nom,Tel,totalttc as Total," +
                "montantrest as 'Montant reste' from fourniseur  inner join achat on achat.c_fr = fourniseur.c_fr where montantrest > 0  limit " + limit
                + " offset (" + limit + "* " + (currentPage - 1) + ");";

            DataTable table = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }



                connection.Close();

            }

            return table;
        }
        public DataTable searchDebts(string replace, int limit, int currentPage, int type)
        {
            DataTable table = new DataTable();
            string query;


            if (type == 0)
            {
                replace.Replace("00:00:00", string.Empty);

                replace.Trim();
                string[] values = replace.Split('-');

                query = "SELECT datea as Date,client.c_cl,nom,tel,totalttc as Total," +
                    "montantrest from client inner join ventes on client.c_cl = ventes.c_cl  where " +
                    "strftime('%Y', ventes.Datea) = '" + values[2] + "' and strftime('%m',ventes.Datea) = '" + values[1] + "' and " +
                    "strftime('%d', ventes.Datea) = '" + values[0] + "' and ventes.montantrest > 0; ";
            }
            else
            {
                query = " select datea as Date,client.c_cl,nom,tel,totalttc as Total,montantrest from client inner join ventes on client.c_cl = ventes.c_cl " +
                    "  where (nom like '%" + replace + "%'or tel like '%" + replace + "%' or client.c_cl like '" + replace + "') and montantrest > 0 limit "
                    + limit + " offset (" + limit + "* " + (currentPage - 1) + ");;";
            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);


                adapter.Fill(table);



                connection.Close();
                return table;

            }
        }
        public List<string> GetMostBuyedProducts(string clientID)
        {

            List<string> prods = new List<string>();

            string query = "SELECT client.nom ,l_ventes.quantité , produits.nom as products from" +
                " produits inner join l_ventes on produits.c_prd = l_ventes.c_pr inner join client on" +
                " client.c_cl = l_ventes.c_cl where client.c_cl like '%" + clientID + "%' order by" +
                " quantité desc limit 3;";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            prods.Add(reader.GetString(2));
                        }
                    }

                }
                connection.Close();
            }

            return prods;
        }

        public DataTable searchSuppliers(string search)
        {
            DataTable table = new DataTable();

            string query = "SELECT c_fr as Réf, nom as Nom,tel as Téléphone, Adresse as Adresse" +
                " ,email as Email,activite as Activité,dateajout as 'Date d''ajout' " +
               " from fourniseur where c_fr like '%" + search + "%' or nom like '%" + search + "%' or tel like '%" + search + "%'" +
               " or email like '%" + search + "%';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {

                    adapter.Fill(table);
                }
                connection.Close();
            }

            return table;

        }
        public static DataTable GetSuppliers(int limit, int currentPage)
        {
            DataTable supps = new DataTable();

            string query = "SELECT c_fr as Réf, nom as Nom,tel as Téléphone, Adresse as Adresse ,email as Email,activite as Activité,dateajout as 'Date d''ajout' " +
                " from fourniseur limit " + limit + " offset (" + limit + "*" + (currentPage - 1) + ");  ";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(supps);
                }
                connection.Close();
            }

            return supps;
        }
        public Supplier EditSupplier(string iD, string column, string value)
        {

            Supplier supp = new Supplier();
            string text = string.Empty;
            string name = GetSupplier(iD).Nom;

            switch (column)
            {
                case "Address":
                    column = "adresse";
                    text = "L'adresse du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).Adresse + "' a " + value + "'";
                    break;
                case "Activité":
                    column = "Activite";
                    text = "L'activité du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).Activite + "' a '" + value + "'";

                    break;
                case "Telephone":
                    text = "Le telephone du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).Tel + "' a '" + value + "'";
                    column = "tel";
                    break;
                case "Nom":
                    text = "Le Nom du fournisseur: " + name + " a été modifé du '" + name + "' a '" + value + "'";

                    break;
                case "Email":
                    text = "L'Email du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).Email + "' a '" + value + "'";

                    break;
                case "Fax":
                    text = "Le Fax du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).Fax + "' a '" + value + "'";

                    break;
                case "NIS":
                    text = "Le NIS du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).NIS + "' a '" + value + "'";

                    break;
                case "NIF":
                    text = "Le NIF du fournisseur: " + name + " a été modifé du '" + GetSupplier(iD).NIF + "' a '" + value + "'";

                    break;


            }

            string query = "update fourniseur set " + column + " = '" + value + "' " +
                " where c_fr = '" + iD + "';";

            InsertIntoLog(text);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return GetSupplier(iD);
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }


        }
        public static Supplier GetSupplier(string iD)
        {

            string query = "SELECT nom,tel, adresse,email,c_fr,activite,nis,nif,rc,fax,dateajout " +
                "from fourniseur where c_fr = '" + iD + "';";
            Supplier supplier = null;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nom = (reader.GetValue(0) != DBNull.Value) ? reader.GetString(0) : "Non disponible",
                                 tel = (reader.GetValue(1) != DBNull.Value) ? reader.GetString(1) : "Non disponible",
                                 adresse = (reader.GetValue(2) != DBNull.Value) ? reader.GetString(2) : "Non disponible",
                                  rc = (reader.GetValue(8) != DBNull.Value) ? reader.GetString(8) : "Non disponible",
                                     email = (reader.GetValue(3) != DBNull.Value) ? reader.GetString(3) : "Non disponible"
                                 , c_fr = (reader.GetValue(4) != DBNull.Value) ? reader.GetString(4) : "Non disponible"
                                 , activite = (reader.GetValue(5) != DBNull.Value) ? reader.GetString(5) : "Non disponible"
                                 , nis = (reader.GetValue(6) != DBNull.Value) ? reader.GetString(6) : "Non disponible"
                                 , nif = (reader.GetValue(7) != DBNull.Value) ? reader.GetString(7) : "Non disponible",
                                 fax = (reader.GetValue(9) != DBNull.Value) ? reader.GetString(9) : "Non disponible"
                                 , dateajout = (reader.GetValue(10) != DBNull.Value) ? reader.GetString(10) : "Non disponible";

                            supplier = new Supplier();
                            supplier.Nom = nom;
                            supplier.Tel = tel;
                            supplier.Adresse = adresse;
                            supplier.Email = email;
                            supplier.C_fr = c_fr;
                            supplier.Activite = activite;
                            supplier.NIS = nis;
                            supplier.NIF = nif;
                            supplier.RC = rc;
                            supplier.Fax = fax;
                            supplier.DateAjout = dateajout;
                        }

                    }
                }
                connection.Close();

                return supplier;
            }




        }

        public Client EditClient(string iD, string column, string value)
        {

            Client supp = new Client();
            string text = string.Empty;
            string name = GetClient(iD).Nom;

            switch (column.ToLower())
            {
                case "address":
                    column = "adresse";
                    break;
                case "activité":
                    column = "Activite";
                    break;
                case "telephone":
                    column = "tel";
                    break;
                case "dateajout":
                    column = "datajout";
                    break;
                case "nom":
                    text = "Le Nom du client: " + name + " a été modifé du '" + name + "' a '" + value + "'";

                    break;
                case "email":
                    text = "L'Email du client: " + name + " a été modifé du '" + GetSupplier(iD).Email + "' a '" + value + "'";

                    break;
                case "fax":
                    text = "Le Fax du client: " + name + " a été modifé du '" + GetSupplier(iD).Fax + "' a '" + value + "'";

                    break;
                case "nis":
                    text = "Le NIS du client: " + name + " a été modifé du '" + GetSupplier(iD).NIS + "' a '" + value + "'";

                    break;
                case "nif":
                    text = "Le NIF du client: " + name + " a été modifé du '" + GetSupplier(iD).NIF + "' a '" + value + "'";

                    break;


            }

            string query = "update client set " + column + " = '" + value + "' " +
                " where c_cl = '" + iD + "';";

            InsertIntoLog(text);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return GetClient(iD);
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }


        }
        public static Client GetClient(string iD)
        {

            string query = "SELECT nom,tel, adresse,email,c_cl,activite,nis,nif,rc,fax,datajout " +
                "from client where c_cl = '" + iD + "';";
            Client client = null;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nom = (reader.GetValue(0) != DBNull.Value) ? reader.GetString(0) : "Non disponible",
                                tel = (reader.GetValue(1) != DBNull.Value) ? reader.GetString(1) : "Non disponible",
                                adresse = (reader.GetValue(2) != DBNull.Value) ? reader.GetString(2) : "Non disponible"
                                , email = (reader.GetValue(3) != DBNull.Value) ? reader.GetString(3) : "Non disponible"
                                , c_fr = (reader.GetValue(4) != DBNull.Value) ? reader.GetString(4) : "Non disponible"
                                , activite = (reader.GetValue(5) != DBNull.Value) ? reader.GetString(5) : "Non disponible"
                                , nis = (reader.GetValue(6) != DBNull.Value) ? reader.GetString(6) : "Non disponible"
                                , nif = (reader.GetValue(7) != DBNull.Value) ? reader.GetString(7) : "Non disponible",
                                fax = (reader.GetValue(9) != DBNull.Value) ? reader.GetString(9) : "Non disponible"
                                , dateajout = (reader.GetValue(10) != DBNull.Value) ? reader.GetString(10) : "Non disponible";
                            client = new Client();
                            client.Nom = nom;
                            client.Tel = tel;
                            client.Adresse = adresse;
                            client.Email = email;
                            client.C_CL = c_fr;
                            client.Activite = activite;
                            client.NIS = nis;
                            client.NIF = nif;
                            client.Fax = fax;
                            client.DatAjout = dateajout;
                        }

                    }
                }
                connection.Close();

                return client;
            }




        }

        public bool InsertSupplier(Supplier supplier)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder columnsBuilder = new StringBuilder();

            Type myType = typeof(Supplier);

            PropertyInfo[] properties = myType.GetProperties();



            foreach (PropertyInfo property in properties)
            {
                if (property.Name.ToLower()
                 == "debts") { continue; }

                object value = property.GetValue(supplier);
                columnsBuilder.Append(property.Name + ",");

                if (property.Name.ToLower()
                    == "dateajout")
                {
                    builder.Append("'" + DateTime.Now.Date.ToString("yyyy-MM-dd").
                        Replace("00:00:00", string.Empty).Replace("/", "-").Trim() + "',");

                    continue;
                }


                if (value == null)
                {
                    builder.Append("'Non disponible',");
                    continue;
                }
                else
                {

                    builder.Append("'" + value.ToString() + "',");

                }


            }


            InsertIntoLog("Un fournisseur sous le nom de: " + supplier.Nom + " a été ajouté");

            string query = "insert into fourniseur (" + columnsBuilder.ToString().Trim(',') + ") values (" + builder.ToString().Trim(',') + ");";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();

                    if (supplier.Debts > 0)
                    {
                        AddEmptyBill(supplier: supplier);
                    }

                    return true;
                }
                else
                {
                    connection.Close();

                    return false;
                }
            }



        }

        public bool AddClient(Client client)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder columnsBuilder = new StringBuilder();

            Type myType = typeof(Client);

            PropertyInfo[] properties = myType.GetProperties();

            string c_cl = generateID("CL", Tables.Client);



            foreach (PropertyInfo property in properties)
            {
                if (property.Name.ToLower()
               == "debts") { continue; }

                object value = property.GetValue(client);
                columnsBuilder.Append(property.Name + ",");

                if (property.Name.ToLower() == "c_cl")
                {
                    builder.Append("'" + c_cl + "',");
                    continue;
                }


                if (value == null)
                {
                    builder.Append("'Non disponible',");
                    continue;
                }
                else
                {
                    if (property.Name == "DatAjout")
                    {
                        DateTime dateTime = DateTime.Parse(value.ToString());

                        string[] date = dateTime.ToString("yyyy-MM-dd").Split('-');
                        string dateString = date[0] + "-" + date[1] + "-" + date[2];

                        builder.Append("'" + dateString + "',");

                    }
                    else
                    {
                        builder.Append("'" + value.ToString() + "',");

                    }

                }


            }
            string query = "insert into CLIENT  (" + columnsBuilder.ToString().Trim(',') + ") values (" + builder.ToString().Trim(',') + ");;";
            InsertIntoLog("Un client sous le nom de: " + client.Nom + " et la référence de: " + c_cl + " a été ajouté");

            client.C_CL = c_cl.Clone().ToString();


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();
                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();

                    if (client.Debts > 0)
                    {
                        AddEmptyBill(client: client);
                    }
                    return true;
                }
                else
                {
                    connection.Close();

                    return false;
                }
            }

        }

        public int AddEmptyBill(Client client = null, Supplier supplier = null)
        {
            int done = 0;
            string query = (client != null) ?
                "insert into Ventes ([N],[Type],[DateA],[C_CL],[TotalTTC]" +
            ",[ModeReglement],[Regler]," +
            "[MontantRegler],[MontantRest],totalremise,[TauxTVA],user,benefice)" +
            " values(@ID,@type,@date,@c_cl,@total," +
            "@modeReglement,@regler,@mregler,@mreste,@TR,@tva, @user,@benefice);" :

            "insert into Achat ([N],[Type],[DateA],[C_FR],[TotalTTC]" +
                ",[ModeReglement],[Regler]," +
                "[MontantRegler],[MontantRest],[TauxTVA],user) values(@ID,@type,@date,@c_fr,@total," +
                "@modeReglement,@regler,@mregler,@mreste,@tva, @user);";

            string BillID = (client != null) ? generateID("BL", Tables.ventes) : generateID(string.Empty, Tables.Achat);

            string S_dateString = string.Empty, C_dateString = string.Empty;

            if (client != null)
            {
                string[] ClientAddedDate = client.DatAjout.Split('/');
                C_dateString = ClientAddedDate[2] + "-" + ClientAddedDate[1] + "-" + ClientAddedDate[0];
            }
            else
            {
                string[] SuppAddedDate = supplier.DateAjout.Split('-');
                S_dateString = SuppAddedDate[2] + "-" + SuppAddedDate[1] + "-" + SuppAddedDate[0];
            }




            SQLiteParameter[] paramms = (client != null) ? new SQLiteParameter[]
            {  new SQLiteParameter("@ID", BillID),
                     new SQLiteParameter("@type", "Dette"),
                 new SQLiteParameter("@date", C_dateString)
                 ,new SQLiteParameter("@c_cl", client.C_CL),
                             new SQLiteParameter("@total",client.Debts),
                             new SQLiteParameter("@modeReglement", "NONE"),
                              new SQLiteParameter("@regler", "Non Réglé"),
                              new SQLiteParameter("@mregler", "0"),
                              new SQLiteParameter("@user", Properties.Settings.Default.LoggedInUserID+"("+Properties.Settings.Default.LoggedInUserName+")"),
                              new SQLiteParameter("@benefice","0"),
                                new SQLiteParameter("@mreste", client.Debts),
                              new SQLiteParameter("@TR", "0"),
                               new SQLiteParameter("@tva", "0"),
                                new SQLiteParameter("@tva", "0")
            } :

            new SQLiteParameter[]
            {

                    new SQLiteParameter("@ID", BillID),
                    new SQLiteParameter("@type", "Dette"),
                    new SQLiteParameter("@date", S_dateString),
                    new SQLiteParameter("@c_fr", supplier.C_fr),
                    new SQLiteParameter("@total", "0"),
                    new SQLiteParameter("@modeReglement", "Cash"),
                    new SQLiteParameter("@regler", "Non Réglé"),
                    new SQLiteParameter("@mregler","0"),
                    new SQLiteParameter("@user", Properties.Settings.
                    Default.LoggedInUserID+"("+Properties.Settings.Default.LoggedInUserName+")"),

                    new SQLiteParameter("@mreste", supplier.Debts),
                    new SQLiteParameter("@tva","0")

            };


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {


                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(paramms);
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        done = 1;
                    }
                    else
                    {
                        connection.Close();
                        done = 0;
                    }

                }
            }
            SaleLine emptySale = new SaleLine();
            emptySale.N = BillID;
            emptySale.Type = "Dette";
            emptySale.Nomproduit = "NONE";
            emptySale.PrixHT = 0;
            emptySale.Quantité = 0;
            emptySale.C_PR = "X";

            if ((supplier != null) && (supplier.Debts > 0))
            {

                InsertIntoStockHistory(emptySale, supplier.C_fr);
            }
            else if ((client != null) && (client.Debts > 0))
            {
                InsertIntoStockHistory(emptySale, client.C_CL);

            }


            return done;
        }
        public DataTable SelectProductBySupplierID(string ID)
        {

            string query = "select DISTINCT c_prd as Réf,produits.[Nom],produits.[Unit] as Unité,produits.[Type],produits.[Prix_VenteHT] as" +
                " 'Prix en Detail',produits.[PrixVGros] as 'Prix en Gros', produits.[Q_Stock] as 'Disponible'" +
                " from produits inner join L_Achats on Produits.C_Prd= L_Achats.C_PR INNER join achat " +
                "on achat.n = l_achats.n where achat.c_fr = '" + ID + "' ;";

            DataTable table = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }



                connection.Close();

            }

            return table;
        }


        public double GetDebtsByID(string ID)
        {
            string query = "select COALESCE(SUM(montantrest), 0) from Achat where montantrest > 0 and c_fr = '" + ID + "'; ";

            double val = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            val = reader.GetDouble(0);
                        }

                        reader.Close();
                    }
                }



                connection.Close();

            }

            return val;
        }
        public double GetTotalSupplierPurchases(string ID)
        {
            double amount = 0;
            string query = "select sum(prixht * quantité) from l_achats where c_pr" +
            "= (select c_pr from l_achats inner join achat on achat.n = l_achats.n where c_fr = '" + ID + "')  ; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    try
                    {
                        amount = Convert.ToDouble(command.ExecuteScalar());

                    }
                    catch (Exception)
                    {

                        amount = 0;
                    }
                }
                connection.Close();
            }

            return amount;
        }

        public string[] GetTopSoldProductsNames()
        {
            List<string> products = new List<string>();


            string query = " select nom , datea, count(c_pr) as  sales from l_ventes" +
                " inner join produits on produits.c_prd = l_ventes.c_pr group by" +
                "  produits.nom order by sales desc limit 5;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            products.Add(reader.GetString(0));
                        }

                        reader.Close();
                    }
                }



                connection.Close();
            }

            if (products.Count > 0)
            {
                return products.ToArray();
            }
            else
            {
                return null;
            }
        }
        public double[] GetTopSoldProductsTotals()
        {
            List<double> products = new List<double>();


            string query = " select nom , datea, count(c_pr) as  sales, quantité*prixht*count(c_pr) as total from l_ventes " +
                 "inner join produits on produits.c_prd = l_ventes.c_pr group by " +
                  "produits.nom order by sales,total desc limit 5; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            products.Add(reader.GetDouble(3));
                        }

                        reader.Close();
                    }
                }



                connection.Close();
            }

            return products.ToArray();
        }
        public string[] GetTopSoldProductsTotalQT()
        {
            List<string> products = new List<string>();


            string query = " select nom , datea, count(c_pr) as  sales, quantité*count(c_pr) as totalQT from l_ventes " +
                 "inner join produits on produits.c_prd = l_ventes.c_pr group by " +
                  "produits.nom order by sales desc limit 5; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            products.Add(Convert.ToString(reader.GetDouble(3)));
                        }

                        reader.Close();
                    }
                }



                connection.Close();
            }

            return products.ToArray();
        }
        public Dictionary<string, double> GetTopSoldProductsByDate()
        {
            Dictionary<string, double> saleByDate = new Dictionary<string, double>();
            Dictionary<string, double> Reversed = new Dictionary<string, double>();

            string query = " select datea,prixht*quantité*count(c_pr) as totalQT from l_ventes " +
                " inner join produits on produits.c_prd = l_ventes.c_pr group by" +
               "  datea order by datea desc limit 5; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            saleByDate.Add(reader.GetString(0), reader.GetDouble(1));
                        }

                        reader.Close();
                    }
                }



                connection.Close();
            }

            for (int inc = saleByDate.Count - 1; inc >= 0; inc--)
            {
                Reversed.Add(saleByDate.Keys.ToArray()[inc],
                    saleByDate[saleByDate.Keys.ToArray()[inc]]);
            }

            return Reversed;
        }
        public static string IsProductIDAvailable()
        {
            string name = string.Empty;
            string query = "select id from AvailableIDs ORDER BY id asc LIMIT 1;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name = reader.GetValue(0).ToString();

                        }
                        else
                        {
                            name = string.Empty;
                        }


                        reader.Close();
                    }

                    if (name != string.Empty)
                    {
                        cmd.CommandText = "delete from AvailableIDs where id = '" + name + "';";
                        cmd.ExecuteNonQuery();
                    }
                }



                connection.Close();
            }

            return name;

        }
        public static Information GetStoreInformation()
        {
            string query = "select Nom, Activite, Adresse, Tel, Fax, Email, RC, NIF, Logo, QR, CodeBarre from information;";
            Information inf = new Information();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inf = new Information()
                            {
                                Nom = reader.GetString(0),
                                Activite = reader.GetString(1),

                                Adresse = reader.GetString(2),

                                Tel = reader.GetString(3),
                                Fax = reader.GetString(4),
                                Email = reader.GetString(5),
                                RC = reader.GetString(6),
                                NIF = reader.GetString(7),
                                Logo = (reader.GetValue(8) != DBNull.Value) ? reader.GetString(8) : string.Empty,
                                QR = (reader.GetValue(9) != DBNull.Value) ? reader.GetString(9) : string.Empty,
                                CodeBarre = reader.GetString(10),
                            };


                        }



                        reader.Close();
                    }
                }



                connection.Close();
                return inf;
            }
        }
        public DataTable GetNewestProducts(int duration)
        {
            DataTable dt = new DataTable();


            string query = "SELECT c_prd as Référence,[Nom],[Unit],[Type],PRIX_achat as 'Prix d''achat',[Prix_VenteHT] as " +
            "'Prix en Detail',[PrixVGros] as 'Prix en Gros', [Q_Stock] as 'Disponible' " +
            "  FROM [produits] WHERE dateajout >= DATE('now', '-" + duration + " days')" +
                " and produits.q_stock > 0 order by dateajout desc; ";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();



                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }




                connection.Close();
            }
            return dt;
        }

        public int AddEmptyInvoice(Product product)
        {
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd").
                        Replace("00:00:00", string.Empty).Replace("/", "-").Trim();
            string id = generateID(string.Empty, Tables.Achat);


            string insertIntoAchat = "insert into Achat ([N],[Type],[DateA],[C_FR],[TotalTTC]" +
                ",[ModeReglement],[Regler]," +
                "[MontantRegler],[MontantRest],[TauxTVA],user) values(@ID,@type,@date,@c_fr,@total,@modeReglement,@regler,@mregler,@mreste,@tva, @user);";

            string L_Achats_query = "insert into l_Achats ([N], [Type], [DateA]" +
                ",c_pr,[nomproduit],[quantité]," +
                "[prixht],[remise]) values('" + id + "','Ajout','" + date + "', '" + product.ID + "','" +
                product.Name + "'," + product.Quantity + "," + product.PriceP.ToString().Replace(",", ".") + ",0 )";

            SaleLine emptySale = new SaleLine();
            emptySale.N = id;
            emptySale.Type = "Ajout";
            emptySale.Nomproduit = product.Name;
            emptySale.PrixHT = product.PriceP;
            emptySale.Quantité = product.Quantity;
            emptySale.C_PR = product.ID;

            InsertIntoStockHistory(emptySale, "1");


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                SQLiteCommand achatCommand = new SQLiteCommand(insertIntoAchat, connection);
                SQLiteCommand l_achatCommand = new SQLiteCommand(L_Achats_query, connection);
                SQLiteParameter sQLiteParameter = new SQLiteParameter("@ID", id),
                      sQLiteParameter1 = new SQLiteParameter("@type", "Ajout"),
                      sQLiteParameter2 = new SQLiteParameter("@date", date),
                      sQLiteParameter3 = new SQLiteParameter("@c_fr", 1),
                      sQLiteParameter4 = new SQLiteParameter("@total", "0"),
                      sQLiteParameter5 = new SQLiteParameter("@modeReglement", "NONE"),
                      sQLiteParameter6 = new SQLiteParameter("@regler", "0"),
                      sQLiteParameter7 = new SQLiteParameter("@mregler", "0"),
                      sQLiteParameterU = new SQLiteParameter("@user", Properties.Settings.Default.LoggedInUserID + "(" + Properties.Settings.Default.LoggedInUserName + ")"),

                      sQLiteParameter8 = new SQLiteParameter("@mreste", "0"),
                      sQLiteParameter9 = new SQLiteParameter("@tva", "0");
                SQLiteParameter[] paramms = new SQLiteParameter[] { sQLiteParameter,
    sQLiteParameter1, sQLiteParameter2,sQLiteParameter3,sQLiteParameter4,sQLiteParameter5,sQLiteParameter6
,sQLiteParameter7,sQLiteParameter8,sQLiteParameter9,sQLiteParameterU};

                achatCommand.Parameters.AddRange(paramms);

                connection.Open();
                if (achatCommand.ExecuteNonQuery() > 0)
                {
                    if (l_achatCommand.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return -1;
                    }


                }
                else
                {
                    connection.Close();
                    return -1;
                }




            }
        }
        public string getProductBarcode(string iD)
        {
            string table = iD.Contains("PR") ? "produits" : "emballage";

            string query = "select c_bare from " + table + " where  c_prd ='" + iD + "';";
            string barCode = string.Empty;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    barCode = (string)command.ExecuteScalar();
                    connection.Close();
                }
            }

            return barCode;
        }
        public static string getAddedDate(string iD)
        {
            string query = "select min(datea) from l_achats where  c_pr ='" + iD + "';";
            string date = "Non disponible";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                date = reader.GetString(0);
                            }

                        }
                        catch (Exception)
                        {

                        }

                        reader.Close();
                    }

                    connection.Close();
                }
            }

            return date;
        }

        public int InsertIntoStockHistory(SaleLine sale, string C_FR)
        {
            string date = DateTime.Now.Date.ToString("yyyy-MM-dd").
                     Replace("00:00:00", string.Empty).Replace("/", "-").Trim();

            string tiere = sale.N.Contains("B") || sale.N.Contains("F") ? GetClient(C_FR).Nom : GetSupplier(C_FR).Nom;

            if (sale.Type != "Ajout" && sale.Type != "Dette")
            {
                sale.Type = sale.N.Contains("B") || sale.N.Contains("F") ? "Vente" : "Achat";

            }

            string query = "INSERT INTO [HistProduits] ([Code],[NPiece],[Type],[Design],[Tiere],[Date],[Prix]," +
                "[QteSR],[QteER]) values (@code,@nBill,@type,@des,@tiere,@date,@prix,@qsr,@qer)";


            SQLiteParameter[] parames = new SQLiteParameter[] { new SQLiteParameter("@code", sale.C_PR),
            new SQLiteParameter("@nBill", sale.N),
            new SQLiteParameter("@type", sale.Type),
            new SQLiteParameter("@des", sale.Nomproduit),
            new SQLiteParameter("@tiere", tiere),
            new SQLiteParameter("@date", date),
             new SQLiteParameter("@qsr", sale.N.Contains("B") || sale.N.Contains("F")? sale.Quantité:0),
            new SQLiteParameter("@qer", sale.N.Contains("B") || sale.N.Contains("F")? 0:sale.Quantité),
            new SQLiteParameter("@prix", sale.PrixHT)};

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(parames);

                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();

                        return 1;
                    }
                    else
                    {
                        connection.Close();

                        return 0;
                    }

                }
            }
        }
        public bool ModifyProduct(string selectedColumn, string text, string iD)
        {
            string Logtext = string.Empty;
            string table = iD.Contains("PR") ? "produits" : "emballage";
            Product product = GetProductByID(iD.Contains("PR") ? "produits" : "emballage", iD);


            switch (selectedColumn)
            {
                case "c_pr":
                    Logtext = "La référence du produit: " + iD + " a été modifé du '" + iD + "' a '" + text + "'";

                    break;
                case "nom":
                    Logtext = "Le nom du produit: " + iD + " a été modifé du '" + product.Name + "' a '" + text + "'";

                    break;
                case "q_stock":
                    Logtext = "La quantité du produit: " + iD + " a été modifé du '" + product.Quantity + "' a '" + text + "'";

                    break;
                case "prix_achat":

                    Logtext = "Le prix d'achat du produit: " + iD + " a été modifé du '" + product.PriceP + "' a '" + text + "'";

                    break;
                case "prix_venteHT":
                    Logtext = "Le prix de vente au détail du produit: " + iD + " a été modifé du '" + product.PriceD + "' a '" + text + "'";

                    break;
                case "prixvgros":
                    Logtext = "Le prix de vente en gros du produit: " + iD + " a été modifé du '" + product.PriceG + "' a '" + text + "'";

                    break;
                case "stock_alerte":
                    Logtext = "L'alerte de stock du produit: " + iD + " a été modifé du '" + product.StockAlert + "' a '" + text + "'";

                    break;
            }
            InsertIntoLog(Logtext);

            string query = " update " + table + " set " + selectedColumn + " = '" + text + "'  where c_prd ='" + iD.Trim() + "';";

            if (selectedColumn != "nom" && selectedColumn != "c_pr" && selectedColumn != "c_fr")
            {
                query = " update " + table + " set " + selectedColumn + " = " + text + "  where c_prd ='" + iD + "';";
            }
            bool done = false;


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        done = true;
                    }

                    connection.Close();
                }
            }

            return done;
        }
        public DataTable GetInventory(int limit, int currentPage)
        {
            DataTable dt = new DataTable();


            string query = "SELECT [Code] as Référence" +
                         " ,[NomProduit] as 'Nom de produit'" +
                         " ,[PrixVente] as 'Prix de vente'" +

                         " ,[Entre] as Entrés" +
                         " ,[Sortie] as Sorties" +
                         " ,PrixAchat as 'Prix d''achat'" +
                          ",[codeBarre] as 'Code-Barres'" +
                      " FROM[Stock] inner join produits on stock.code = produits.c_prd order by produits.c_prd limit "
                      + limit + " offset (" + limit + "* " + (currentPage - 1) + ");";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();



                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }




                connection.Close();
            }
            return dt;
        }
        public object GetStockByType(string type, int limit, int currentPage)
        {
            string query = "SELECT [Code] as Référence" +
                         " ,[NomProduit] as 'Nom de produit'" +
                         " ,[PrixVente] as 'Prix de vente'" +

                         " ,[Entre] as Entrés" +
                         " ,[Sortie] as Sorties" +
                         " ,PrixAchat as 'Prix d''achat'" +

                          ",[codeBarre] as 'Code-Barres'" +
                     "  FROM [stock] inner join produits on stock.code = produits.c_prd where type like '" + type + "' limit " + limit + " offset " + (currentPage - 1) * limit + ";";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }
        public string GetScarceProductsNumber(out string shortageNumber)
        {
            string query = "select count(code) from stock ;";
            string query1 = "select count(c_prd) from produits where q_stock <= stock_alerte;";
            string embquery = "select count(c_prd) from emballage where q_stock <= stock_alerte;";
            string p_number = string.Empty;
            shortageNumber = string.Empty;


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                p_number = reader.GetInt32(0).ToString();
                                reader.Close();

                                command.CommandText = query1;

                                shortageNumber = command.ExecuteScalar().ToString();

                                command.CommandText = embquery;
                                shortageNumber = (int.Parse(command.ExecuteScalar().ToString()) +
                                int.Parse(shortageNumber)).ToString();

                            }

                        }
                        catch (Exception)
                        {
                            MessageBoxer.showErrorMsg("Une erreur s'est produite");
                        }
                        finally
                        {
                            reader.Close();
                            connection.Close();

                        }

                    }


                }
            }

            return p_number;
        }
        public DataTable searchForItem(string search)
        {
            string query = "SELECT [Code] as Référence" +
                         " ,[NomProduit] as 'Nom de produit'" +
                         " ,[PrixVente] as 'Prix de vente'" +

                         " ,[Entre] as Entrés" +
                         " ,[Sortie] as Sorties" +
                         " ,PrixAchat as 'Prix d''achat'" +
                          ",[codeBarre] as 'Code-Barres'" +
                     "  FROM [stock] inner join produits on stock.code = produits.c_prd where lower(nom) like '%" + search
                     + "%' or lower(c_prd) like '%" + search + "%' ;";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }

        public DataTable getHistory(int limit, int currentPage)
        {
            string query = "select [NLigne] as Ligne ,[Code]" +
           ",[NPiece] as 'N° Bon'" +
           ",[Type] as 'Opération',[Design] as Désignation,[Tiere],[Date],[Prix],[QteSR] as 'QT Sortie'" +
           ",[QteER] as 'QT Entrée'  FROM histproduits order by date desc limit " + limit + " offset " + (currentPage - 1) * limit + ";";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();
                return table;

            }
        }
        public DataTable searchHistory(int selection, string search)
        {
            DataTable table = new DataTable();

            string query = "select [NLigne] as Ligne ,[Code]" +
          ",[NPiece] as 'N° Bon'" +
          ",[Type] as 'Opération',[Design] as Désignation,[Tiere],[Date],[Prix],[QteSR] as 'QT Sortie'" +
          ",[QteER] as 'QT Entrée'  FROM histproduits where lower(tiere) like '%" + search + "%' or lower(Design) like '%" + search +
          "%' or lower(code) like '%" + search + "%' or lower(npiece) like '%" + search + "%' order by date desc ;";


            switch (selection)
            {
                case 1:


                    search = search.Replace("00:00:00", string.Empty).Trim();
                    string[] values = search.Split('-');

                    query = "select [NLigne] as Ligne ,[Code]" +
      ",[NPiece] as 'N° Bon'" +
      ",[Type] as 'Opération',[Design] as Désignation,[Tiere],[Date],[Prix],[QteSR] as 'QT Sortie'" +
      ",[QteER] as 'QT Entrée'  FROM histproduits  where  strftime('%Y',Date) = '" + values[2].Trim() +
      "' and strftime('%m',Date) = '" + values[1].Trim() + "' and strftime('%d',Date) = '" + values[0].Trim()
      + "'order by date desc ;";
                    break;
                case 2:
                    query = "select [NLigne] as Ligne ,[Code]" +
     ",[NPiece] as 'N° Bon'" +
     ",[Type] as 'Opération',[Design] as Désignation,[Tiere],[Date],[Prix],[QteSR] as 'QT Sortie'" +
     ",[QteER] as 'QT Entrée'  FROM histproduits  where type = '" + search + "' order by date desc limit 200 ;";
                    break;

            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();

            }

            return table;
        }

        public int DeleteFromHistory(List<string> IDs, bool All)
        {

            int done = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    if (!All)
                    {
                        foreach (string id in IDs)
                        {
                            string query = "delete from histproduits where NLigne = " + id + ";";

                            command.CommandText = query;

                            try
                            {
                                command.ExecuteNonQuery();
                                done = 1;

                            }
                            catch (Exception)
                            {
                                connection.Close();
                                done = 0;
                            }

                        }
                    }
                    else
                    {
                        string query = "delete from histproduits;  DELETE FROM sqlite_sequence WHERE name='HistProduits';";

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();
                            done = 1;

                        }
                        catch (Exception)
                        {
                            connection.Close();
                            done = 0;
                        }
                    }
                    connection.Close();


                }
            }

            return done;
        }
        public AutoCompleteStringCollection GetCustomerNames(string name, out List<Client> customers)
        {
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            string query = "SELECT c_cl , nom, tel, adresse FROM client WHERE nom LIKE @name;";
            customers = new List<Client>();
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", "%" + name + "%");

                    connection.Open();

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Client client = new Client();
                            client.Adresse = (reader.GetValue(3) != DBNull.Value) ? reader.GetString(3) : "Non disponible";
                            client.Tel = (reader.GetValue(2) != DBNull.Value) ? reader.GetString(2) : "Non disponible";
                            client.C_CL = reader.GetString(0);
                            client.Nom = reader.GetString(1);
                            names.Add(reader.GetString(1));
                            customers.Add(client);
                        }
                    }
                }
                connection.Close();
            }

            return names;
        }

        bool UpateStockSale(SaleLine saleLine)
        {
            string add_to_Operations = "update [Stock] set [NomProduit] = '" + saleLine.Nomproduit.Replace("'", "''")
    + "',[PrixVente] = " + saleLine.PrixHT.ToString(nfi) + " " +
    ",[Sortie] = Sortie+" + saleLine.Quantité.ToString(nfi) + "  where code = '" + saleLine.C_PR + "' ;";

            bool done = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand operations = new SQLiteCommand(add_to_Operations, connection))
                {
                    connection.Open();

                    if (operations.ExecuteNonQuery() > 0)
                    {

                        done = true;

                    }

                    connection.Close();
                }


                return done;
            }
        }
        int EditProductSale(SaleLine saleLine)
        {
            string table = saleLine.C_PR.Contains("FL") ? "emballage" : "produits";

            string checklength = "update " + table + " set q_stock = q_stock-@quantity" +
              "  where c_prd = @id ;";

            SQLiteParameter parameter3 = new SQLiteParameter("@quantity", saleLine.Quantité.ToString(nfi)),
                    parameter4 = new SQLiteParameter("@id", saleLine.C_PR);

            SQLiteParameter[] parameters = new SQLiteParameter[] { parameter3, parameter4 };


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkL = new SQLiteCommand(checklength, connection);
                checkL.Parameters.AddRange(parameters);



                if (checkL.ExecuteNonQuery() > 0)
                {
                    connection.Close();

                    return 1;
                }
                else
                {
                    connection.Close();

                    return 0;
                }





            }
        }
        public int AddSaleLines(SaleLine saleLine)

        {
            string insertAchatLine;
            string date = saleLine.DateA.Date.Year + "-" +
                    saleLine.DateA.Date.Month.ToString("D2") + "-" +
                    saleLine.DateA.Date.Day.ToString("D2");

            string BillID = saleLine.N
                , BillType = saleLine.Type.Trim(),
                 C_PR = saleLine.C_PR,
                 Nom_PR = saleLine.Nomproduit
                 , QT = saleLine.Quantité.ToString().Replace(",", "."),
                 PRIX = saleLine.PrixHT.ToString(nfi).Replace(",", "."),
                 Remise = saleLine.Remise.ToString().Replace(",", ".")
                 , Marge = saleLine.Marge.ToString().Replace(",", "."),
                 C_CL = saleLine.C_CL,
                 MontantHT = saleLine.MontantHT.ToString().Replace(",", ".");



            insertAchatLine = "insert into l_ventes ([N], [Type], [DateA]" +
             ",c_pr,[nomproduit],[quantité]," +
             "[prixht],[remise],marge,c_cl,MontantHT) " +
             "values('" + BillID + "','" + BillType +
             "','" + date + "','" + C_PR + "',@Nom_PR," + QT + "," + PRIX + "," + Remise +
             "," + Marge + ",'" + C_CL + "'," + MontantHT + ");";



            UpateStockSale(saleLine);
            EditProductSale(saleLine);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(insertAchatLine, connection))

                {
                    command.Parameters.AddWithValue("@Nom_PR", Nom_PR);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }

                }
            }
        }
        public bool Earn(double total, User user, string date,
            string nomClient, string n, string Op, double outs)
        {

            string update_expenses = "update [Caisse] set [entre] = entre+" + total.ToString("F2")
                .Replace(",", ".") + ";";

            string add_to_Operations = "INSERT INTO [L_Caisse] ([Date],[Tiere],[N_Bon]," +
                "[Operation],[Entre],[Sortie],[User],[u_id]) values('" + date + "','" + nomClient + "','" + n + "','" + Op +
                "'," + total.ToString().Replace(",", ".") + "," + outs + ",'" + user.Name + "','" + user.ID + "')";


            bool done = false;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand expenses = new SQLiteCommand(update_expenses, connection)
                    , operations = new SQLiteCommand(add_to_Operations, connection);

                connection.Open();
                if (expenses.ExecuteNonQuery() > 0)
                {
                    if (operations.ExecuteNonQuery() > 0)
                    {

                        done = true;

                    }
                }


                connection.Close();
                return done;
            }
        }


        public bool CheckAvailability(List<SaleLine> prods, out string ID)
        {
            bool available = false;

            ID = string.Empty;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();
                SQLiteCommand checkL = new SQLiteCommand(connection);




                for (int i = 0; i < prods.Count; i++)
                {
                    string table = prods[i].C_PR.Contains("FL") ? "emballage" : "produits";
                    checkL.CommandText = "select q_stock, c_prd from " + table + " where c_prd = '" + prods[i].C_PR + "' ;";

                    using (SQLiteDataReader reader = checkL.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            if (reader.GetDouble(0) > 0)
                            {

                                available = true;

                            }
                            else
                            {
                                ID = reader.GetString(1);
                                available = false;
                                reader.Close();
                                connection.Close();

                                return available;


                            }
                        }
                        reader.Close();

                    }

                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                return available;



            }
        }

        public int AddSale(List<SaleLine> soldProducts, double total, string NomClient,
            double amountPaid, float tva, string type, out string billID, double TotalReduction)
        {


            User user = new User();
            user.ID = Settings.Default.LoggedInUserID;
            user.Name = Settings.Default.LoggedInUserName;
            double benefice = 0;
            string reglé;
            string ID = (type == "Facture") ? generateID("FA", Tables.ventes) : generateID("BL", Tables.ventes);
            billID = ID.Clone().ToString();
            string BillType = (type == "Facture") ? "Facture" : "Bon";
            string c_cl = soldProducts[0].C_CL;
            double TotalBuyingPrice = 0;

            if (amountPaid != total)
            {
                reglé = "Non Réglé";
            }
            else
            {
                reglé = "Réglé";
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {




                if (NomClient == null)
                {

                    NomClient = "Non disponible";


                }

                string date = soldProducts[0].DateA.Date.Year + "-" +
                    soldProducts[0].DateA.Date.Month.ToString("D2") + "-" +
                    soldProducts[0].DateA.Date.Day.ToString("D2");

                string prodID;

                if (!CheckAvailability(soldProducts, out prodID))
                {
                    MessageBoxer.showGeneralMsg("Le produit " + prodID + " n'est plus disponible. Vérifiez la liste des produits.");

                    return -1;

                }

                for (int i = 0; i < soldProducts.Count; i++)
                {
                    soldProducts[i].N = ID;
                    soldProducts[i].DateA = DateTime.Parse(date);

                    AddSaleLines(soldProducts[i]);
                    InsertIntoStockHistory(soldProducts[i], c_cl);

                    benefice += soldProducts[i].Marge;
                    TotalBuyingPrice += (soldProducts[i].BuyingPrice * soldProducts[i].Quantité);

                }


                benefice -= (TotalReduction * Math.Round(benefice, 2)) / (TotalBuyingPrice + Math.Round(benefice, 2));
                double TVA = (total * tva) / 100;
                if (benefice > 0)
                {
                    benefice -= TVA;

                }
                string insertIntoAchat = "insert into Ventes ([N],[Type],[DateA],[C_CL],[TotalTTC]" +
               ",[ModeReglement],[Regler]," +
               "[MontantRegler],[MontantRest],totalremise,[TauxTVA],user,benefice)" +
               " values(@ID,@type,@date,@c_cl,@total," +
               "@modeReglement,@regler,@mregler,@mreste,@TR,@tva, @user,@benefice);";

                SQLiteParameter sQLiteParameter = new SQLiteParameter("@ID", ID),
                                sQLiteParameter1 = new SQLiteParameter("@type", BillType),
                                sQLiteParameter2 = new SQLiteParameter("@date", date),
                                sQLiteParameter3 = new SQLiteParameter("@c_cl", c_cl),
                                sQLiteParameter4 = new SQLiteParameter("@total", total),
                                sQLiteParameter5 = new SQLiteParameter("@modeReglement", "Cash"),
                                sQLiteParameter6 = new SQLiteParameter("@regler", reglé),
                                sQLiteParameter7 = new SQLiteParameter("@mregler", amountPaid),
                                sQLiteParameterU = new SQLiteParameter("@user", Properties.Settings.Default.LoggedInUserID + "(" + Properties.Settings.Default.LoggedInUserName + ")"),
                                sQLiteParameterB = new SQLiteParameter("@benefice", Math.Round(benefice, 2)),
            /*sQLiteParameterU = new SQLiteParameter("@user", Settings.Default.LoggedInUserID +
            "(" + Settings.Default.LoggedInUserName + ")"),*/
            sQLiteParameter8 = new SQLiteParameter("@mreste", total - amountPaid),
                                sQLiteParametertr = new SQLiteParameter("@TR", TotalReduction),
                                sQLiteParameter9 = new SQLiteParameter("@tva", TVA);
                sQLiteParameter9 = new SQLiteParameter("@tva", (total * tva) / 100);

                SQLiteParameter[] paramms = new SQLiteParameter[] { sQLiteParameter,
                    sQLiteParameter1, sQLiteParameter2,sQLiteParameter3,
                    sQLiteParameter4,sQLiteParameter5,sQLiteParameter6
                ,sQLiteParameter7,sQLiteParameter8,sQLiteParameter9,
                    sQLiteParameterU,sQLiteParametertr,sQLiteParameterB};


                connection.Open();
                SQLiteCommand achatCommand = new SQLiteCommand(insertIntoAchat, connection);
                achatCommand.Parameters.AddRange(paramms);

                if (achatCommand.ExecuteNonQuery() > 0)
                {

                    Earn(amountPaid, user, date, NomClient,
                        soldProducts[0].N, "Vente", 0);



                    connection.Close();

                    InsertIntoLog("Une vente avec la référence: " + ID + " a été effectuée avec un total de: " + total + " DA, versement de: " + amountPaid + " DA");

                    return 1;
                }
                else
                {
                    connection.Close();
                    return -1;
                }







            }
        }

        public int SaveSale(List<SaleLine> soldProducts, double total, string NomClient,
                double amountPaid, float tva, string type, out string billID, double TotalReduction)
        {


            User user = new User();
            user.ID = Settings.Default.LoggedInUserID;
            user.Name = Settings.Default.LoggedInUserName;
            double benefice = 0;
            string reglé;
            string ID = (type == "Facture") ? generateID("TFA", Tables.ventesTemp) : generateID("TBL", Tables.ventesTemp);
            billID = ID.Clone().ToString();
            string BillType = (type == "Facture") ? "Facture" : "Bon";
            string c_cl = soldProducts[0].C_CL;
            double TotalBuyingPrice = 0;

            if (amountPaid != total)
            {
                reglé = "Non Réglé";
            }
            else
            {
                reglé = "Réglé";
            }



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {




                if (NomClient == null)
                {

                    NomClient = "Non disponible";


                }

                string date = soldProducts[0].DateA.Date.Year + "-" +
                    soldProducts[0].DateA.Date.Month.ToString("D2") + "-" +
                    soldProducts[0].DateA.Date.Day.ToString("D2");


                string prodID;

                if (!CheckAvailability(soldProducts, out prodID))
                {
                    MessageBoxer.showGeneralMsg("Le produit " + prodID + " n'est plus disponible. Vérifiez la liste des produits.");

                    return -1;

                }

                for (int i = 0; i < soldProducts.Count; i++)
                {
                    soldProducts[i].N = ID;
                    soldProducts[i].DateA = DateTime.Parse(date);

                    SaveSaleLines(soldProducts[i]);

                    benefice += soldProducts[i].Marge;
                    TotalBuyingPrice += (soldProducts[i].BuyingPrice * soldProducts[i].Quantité);

                }


                benefice -= (TotalReduction * Math.Round(benefice, 2)) / (TotalBuyingPrice + Math.Round(benefice, 2));
                double TVA = (total * tva) / 100;
                if (benefice > 0)
                {
                    benefice -= TVA;

                }
                string insertIntoAchat = "insert into Ventes ([N],[Type],[DateA],[C_CL],[TotalTTC]" +
               ",[ModeReglement],[Regler]," +
               "[MontantRegler],[MontantRest],totalremise,[TauxTVA],user,benefice)" +
               " values(@ID,@type,@date,@c_cl,@total," +
               "@modeReglement,@regler,@mregler,@mreste,@TR,@tva, @user,@benefice);";

                SQLiteParameter sQLiteParameter = new SQLiteParameter("@ID", ID),
                                sQLiteParameter1 = new SQLiteParameter("@type", BillType),
                                sQLiteParameter2 = new SQLiteParameter("@date", date),
                                sQLiteParameter3 = new SQLiteParameter("@c_cl", c_cl),
                                sQLiteParameter4 = new SQLiteParameter("@total", total),
                                sQLiteParameter5 = new SQLiteParameter("@modeReglement", "Cash"),
                                sQLiteParameter6 = new SQLiteParameter("@regler", reglé),
                                sQLiteParameter7 = new SQLiteParameter("@mregler", amountPaid),
                                sQLiteParameterU = new SQLiteParameter("@user", Properties.Settings.Default.LoggedInUserID + "(" + Properties.Settings.Default.LoggedInUserName + ")"),
                                sQLiteParameterB = new SQLiteParameter("@benefice", Math.Round(benefice, 2)),

            sQLiteParameter8 = new SQLiteParameter("@mreste", total - amountPaid),
                                sQLiteParametertr = new SQLiteParameter("@TR", TotalReduction),
                                sQLiteParameter9 = new SQLiteParameter("@tva", TVA);
                sQLiteParameter9 = new SQLiteParameter("@tva", (total * tva) / 100);

                SQLiteParameter[] paramms = new SQLiteParameter[]
                { sQLiteParameter,
                        sQLiteParameter1, sQLiteParameter2,sQLiteParameter3,
                        sQLiteParameter4,sQLiteParameter5,sQLiteParameter6
                     ,sQLiteParameter7,sQLiteParameter8,sQLiteParameter9,
                        sQLiteParameterU,sQLiteParametertr,sQLiteParameterB
                };


                connection.Open();
                SQLiteCommand achatCommand = new SQLiteCommand(insertIntoAchat, connection);
                achatCommand.Parameters.AddRange(paramms);

                if (achatCommand.ExecuteNonQuery() > 0)
                {

                    connection.Close();
                    InsertIntoLog("Une vente avec la référence: " + ID + " a été sauvegardé avec un total de: " + total + " DA");

                    return 1;
                }
                else
                {
                    connection.Close();
                    return -1;
                }







            }
        }

        public int SaveSaleLines(SaleLine saleLine)
        {
            string insertAchatLine;
            string date = saleLine.DateA.Date.Year + "-" +
                    saleLine.DateA.Date.Month.ToString("D2") + "-" +
                    saleLine.DateA.Date.Day.ToString("D2");
            string BillID = saleLine.N
                , BillType = saleLine.Type.Trim(),
            C_PR = saleLine.C_PR,
            Nom_PR = saleLine.Nomproduit
                 , QT = saleLine.Quantité.ToString().Replace(",", "."),
                 PRIX = saleLine.PrixHT.ToString(nfi).Replace(",", "."),
                 Remise = saleLine.Remise.ToString().Replace(",", ".")
                 , Marge = saleLine.Marge.ToString().Replace(",", "."),
            C_CL = saleLine.C_CL,
                 MontantHT = saleLine.MontantHT.ToString().Replace(",", ".");



            insertAchatLine = "insert into l_ventes ([N], [Type], [DateA]" +
             ",c_pr,[nomproduit],[quantité]," +
             "[prixht],[remise],marge,c_cl,MontantHT) " +
             "values('" + BillID + "','" + BillType +
             "','" + date + "','" + C_PR + "',@Nom_PR," + QT + "," + PRIX + "," + Remise +
             "," + Marge + ",'" + C_CL + "'," + MontantHT + ");";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(insertAchatLine, connection))

                {
                    command.Parameters.AddWithValue("@Nom_PR", Nom_PR);

                    connection.Open();
                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }

                }
            }
        }
        public int UpdateBill(double benef, string iD, double total, bool exec, out string newID)
        {
            newID = iD;

            string appendix = string.Empty;

            if (newID.Contains("T") && exec)
            {
                newID = generateID(iD.Substring(1, 2), Tables.ventes);
                appendix = " n = '" + newID + "',";

            }


            string query = "update ventes set " + appendix + " benefice = " + benef.ToString().Replace(",", ".") + ",datea = DATE('now'), totalttc = " + total + " where n = '" + iD + "';";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();

                    return 1;
                }
                else
                {
                    connection.Close();
                    return 0;
                }


            }
        }
        public DataTable selectMoney(string str)
        {
            string query = (str == "DEC") ?
                "SELECT [N_Dec] as Réf,[Date],[User] as Utilisateur,[Motif],[Somme] as Montant FROM [Decaissement];"
                : "SELECT [N_En] as Réf,[Date],[User] as Utilisateur,[Motif],[Somme] as Montant FROM [Encaissement];";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                var table = new DataTable();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);

                adapter.Fill(table);

                connection.Close();

                return table;

            }


        }

        public double GetEntriesAndSpendings(out double sortie)
        {
            string query = "select entre,sortie from caisse; ";
            double entre = 0;
            sortie = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();

                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    entre = (reader.GetValue(0) == DBNull.Value) ? 0 : reader.GetDouble(0);
                    sortie = (reader.GetValue(1) == DBNull.Value) ? 0 : reader.GetDouble(1);

                }
                reader.Close();
                connection.Close();

            }

            return entre;
        }
        public double GetProfit(bool today)
        {
            string date = DateTime.Now.Date.Year + "-" +
                               DateTime.Now.Date.Month.ToString("D2") + "-" +
                                DateTime.Now.Date.Day.ToString("D2");

            string[] values = date.Split('-');

            double profit = 0;
            string query = (today) ? "select sum(benefice) from ventes where strftime('%Y',ventes.[DateA]) = '"
             + values[0].Trim() + "' and strftime('%m',ventes.[DateA]) = '" + values[1].Trim() +
             "' and strftime('%d',ventes.[DateA])= '" + values[2].Trim() + "' and n not like '%T%' ; "
                : "select sum(benefice) from ventes where n not like '%T%' ; ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();

                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    profit = (reader.GetValue(0) == DBNull.Value) ? 0 : reader.GetDouble(0);

                }
                reader.Close();
                connection.Close();

            }

            return profit;


        }
        public double GetZakat()
        {
            string query = "select sum (prix_achat * q_stock) *0.025 from produits;";
            double zakat = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand command = new SQLiteCommand(query, connection);

                connection.Open();

                SQLiteDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    zakat = (reader.GetValue(0) == DBNull.Value) ? 0 : reader.GetDouble(0);

                }
                reader.Close();
                connection.Close();

            }

            return zakat;

        }
        public int DeleteFromRegistry(List<string> IDs)
        {
            int done = 0;


            foreach (string id in IDs)
            {

                InsertIntoLog("La ligne '" + id + "' a été supprimé du registre de la caisse");

            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    foreach (string id in IDs)
                    {
                        string query = "delete from l_caisse where n_bon = '" + id + "';";

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();
                            done = 1;

                        }
                        catch (Exception)
                        {
                            connection.Close();
                            done = 0;
                        }

                    }
                    connection.Close();


                }
            }

            return done;
        }
        public int DeleteWithdrwalsAndDeposits(string op, string column
            , string id, string motif, double amount)
        {
            string query = "delete from " + op + " where " + column + " = '" + id + "';";
            string text = (column == "n_en") ? "L'encaissement '" : "Le décaissement '";
            InsertIntoLog(text + id + "' avec le motif: " + motif + ", montant: " + amount + " DA a été supprimé");

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }
                }
            }


        }

        public bool AddAvailableID(string ID)
        {
            string query = "insert into AvailableIDs values('" + ID + "')";

            using (SQLiteConnection
                 connection = new SQLiteConnection(connectionString))
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    connection.Open();

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public int DeleteProducts(List<string> IDs)
        {

            int done = 0;
            if (IDs[0] != "all")
            {
                foreach (string id in IDs)
                {

                    InsertIntoLog("Le produit '" + id + "' a été supprimé");

                    AddAvailableID(id);

                }
            }
            else
            {
                InsertIntoLog("Tout les produits ont été supprimés");

            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    if (IDs[0] != "all")
                    {
                        foreach (string id in IDs)
                        {
                            string query = "delete from produits where c_prd = '" + id + "';";

                            command.CommandText = query;

                            try
                            {
                                command.ExecuteNonQuery();
                                done = 1;

                            }
                            catch (Exception)
                            {
                                connection.Close();
                                done = 0;
                            }

                        }
                    }
                    else
                    {
                        string query = "delete from produits;";

                        command.CommandText = query;

                        try
                        {
                            command.ExecuteNonQuery();
                            done = 1;

                        }
                        catch (Exception)
                        {
                            connection.Close();
                            done = 0;
                        }
                    }
                    connection.Close();


                }
            }


            if (IDs[0] != "all")
            {
                foreach (string id in IDs)
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();


                        using (SQLiteCommand command = new SQLiteCommand(connection))
                        {
                            command.CommandText = "delete from stock where code = '" + id + "';";
                            command.ExecuteNonQuery();
                        }

                        connection.Close();
                    }

                }
            }
            else
            {
                DeleteFromStock("all");

            }

            return done;
        }
        public DataTable LoadScarceProducts()
        {
            DataTable table = new DataTable();

            string query = "select c_prd as Réf,Nom,q_stock as Disponible from produits where q_stock <= stock_alerte" +
            " UNION select c_prd as Réf,Nom,q_stock from EMBALLAGE where EMBALLAGE.q_stock <= EMBALLAGE.stock_alerte;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                    connection.Close();

                }



            }
            return table;
        }
        public int DeleteFromStock(string selectedID)
        {
            string query = (selectedID != "all") ? "delete from stock where code = '" + selectedID + "';"
                : "delete from stock";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    if (command.ExecuteNonQuery() > 0)
                    {

                        command.CommandText = "delete from produits where c_pr = '" + selectedID + "';";
                        command.ExecuteNonQuery();

                        connection.Close();
                        return 1;
                    }
                    else
                    {
                        connection.Close();
                        return 1;
                    }

                }
            }


        }


        public DataTable LoadLogTable(string condition, int limit, int currentPage)
        {
            DataTable dataTable = new DataTable();

            condition = (condition == "10" || condition == "30") ? "where Date >= DATE('now', '-" + condition + " days')" : string.Empty;

            string query = "SELECT [NLigne] as ID,[Operation] as 'Opération',[Date],[userID] as" +
                " 'ID Utilisateur',[userName] as 'Utilisateur' FROM [LogTable] " + condition + " order by NLigne desc " +
                "limit " + limit + " offset " + (currentPage - 1) * limit + ";";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {

                connection.Open();

                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                    connection.Close();

                }



            }
            return dataTable;

        }
        public bool InsertIntoLog(string Operation)
        {
            string dateString = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "INSERT INTO [LogTable] ([Operation],[Date],[userID],[userName]) values (@op,@date,@uID,@uName)";

            SQLiteParameter[] parameters = new SQLiteParameter[] { new SQLiteParameter("@op",Operation),
            new SQLiteParameter("@date",dateString),
            new SQLiteParameter("@uID",Properties.Settings.Default.LoggedInUserID),
            new SQLiteParameter("@uName",Properties.Settings.Default.LoggedInUserName)};

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }

                }
            }

        }
        public bool DeleteFromLog(bool all, string condition)
        {

            string query = all ? "delete from LogTable; DELETE FROM sqlite_sequence WHERE name='LogTable';" :
                "delete from logtable where date  >= DATE('now', '-" + condition + " days') ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool CheckDebt(string clientID, out double debt)
        {
            string check_qt = "select sum(coalesce(montantrest,0)) from ventes where montantrest > 0 and c_cl = '" + clientID + "' ;";
            debt = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand checkQT = new SQLiteCommand(check_qt, connection);

                connection.Open();
                using (SQLiteDataReader reader = checkQT.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        debt = (reader.GetValue(0) != DBNull.Value) ? reader.GetDouble(0) : 0;

                        if (debt > 0)
                        {
                            reader.Close();
                            connection.Close();

                            return true;
                        }
                        else
                        {
                            reader.Close();
                            connection.Close();
                            return false;
                        }
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }
        public bool CheckZakat(out string date)
        {
            string check_qt = "select n_dec,date from decaissement where motif like 'Zakat' ;";
            date = string.Empty;
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteCommand checkQT = new SQLiteCommand(check_qt, connection);

                connection.Open();
                using (SQLiteDataReader reader = checkQT.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader.GetValue(0) != DBNull.Value)
                        {
                            date = reader.GetString(1);

                            reader.Close();
                            connection.Close();
                            return true;
                        }
                        else
                        {
                            reader.Close();
                            connection.Close();
                            return false;
                        }

                    }
                    else
                    {
                        reader.Close();
                        connection.Close();
                        return false;
                    }
                }
            }

        }

        public bool UpdatePassword(string UID, string newPassword)
        {
            string query = " update user set  pass= @pass where N = @uID";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(new SQLiteParameter[] {new SQLiteParameter("@pass",newPassword) ,
                    new SQLiteParameter("@uID",UID) });


                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool DeleteUser(string ID)
        {
            string query = "delete from user where n = '" + ID + "';";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool AddUser(User user)
        {

            string query = "insert into user values ('" + user.ID + "','" + user.Name + "','" + user.Password + "','" + user.BarCode +
                "'," + user.IsAdmin + "," + user.isActive + ");";


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }

        }
        public bool LogIn(string ID, bool logInOut)
        {
            string query = " update user set  actif= " + logInOut + " where N = @uID";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(new SQLiteParameter[] { new SQLiteParameter("@uID", ID) });


                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool UpdateStoreInfo(string column, string value)
        {
            string query = " update information set " + column + "  = @value";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("@value", value));


                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }
        public bool CheckForStoreInfo()
        {
            string query = "select count(*) from information";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {


                    if (int.Parse(command.ExecuteScalar().ToString()) > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool CheckForConnectedUsers()
        {
            string query = "select count(*) from user where actif = true";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {


                    if (int.Parse(command.ExecuteScalar().ToString()) > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool AddStoreInfo(Information info)
        {
            string query = " INSERT INTO [Information] ([Nom],[Activite],[Adresse],[Tel],[Fax],[Email],[RC],[NIF],[CodeBarre])" +
                "values(@nom,@activite,@adress,@tel,@fax,@email,@rc,@nif,@codeBarre);";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddRange(new SQLiteParameter[]{ new SQLiteParameter("@nom", info.Nom),
                            new SQLiteParameter("@activite", info.Activite),
                            new SQLiteParameter("@adress", info.Adresse),
                            new SQLiteParameter("@tel", info.Tel),
                            new SQLiteParameter("@fax", info.Fax),
                            new SQLiteParameter("@email", info.Email),
                            new SQLiteParameter("@rc", info.RC),
                            new SQLiteParameter("@nif", info.NIF),
                            new SQLiteParameter("@codeBarre", info.CodeBarre)});


                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }
        public bool getSupplierID(string Name, out string SupplierID)
        {
            string query = "select c_fr from fourniseur where nom =@nom ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    SQLiteParameter param = new SQLiteParameter("@nom", Name);
                    command.Parameters.Add(param);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        try
                        {
                            SupplierID = reader.GetString(0);

                        }
                        catch (System.InvalidOperationException)
                        {

                            SupplierID = string.Empty;
                        }
                        reader.Close();

                    }

                    if (!string.IsNullOrEmpty(SupplierID))
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool CorrectProduct(string id)
        {
            string query = " update produits set c_fr  = '1' where c_fr = '" + id + "' ;";



            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {

                    if (command.ExecuteNonQuery() > 0)
                    {
                        connection.Close();
                        return true;
                    }
                    else
                    {
                        connection.Close();
                        return false;
                    }
                }
            }
        }

        public bool Lend(double amount, string c_cl, string motif)
        {

            string checkSales = "select count(*) from ventes where c_cl = '" + c_cl + "';";
            string updateRandomInvoice = "UPDATE ventes SET MontantRest = " + amount + " WHERE ROWID = " +
                " (SELECT ROWID FROM ventes where c_cl = '" + c_cl + "' LIMIT 1);";
            string ID = generateID("FA", Tables.ventes);

            string date = DateTime.Now.Date.Year + "-" +
       DateTime.Now.Date.Month.ToString("D2") + "-" +
       DateTime.Now.Date.Day.ToString("D2");


            string insertIntoAchat = "insert into Ventes ([N],[Type],[DateA],[C_CL],[TotalTTC]" +
                              ",[ModeReglement],[Regler]," +
                              "[MontantRegler],[MontantRest],totalremise,[TauxTVA],user,benefice)" +
                              " values(@ID,@type,@date,@c_cl,@total," +
                              "@modeReglement,@regler,@mregler,@mreste,@TR,@tva, @user,@benefice);";

            SQLiteParameter sQLiteParameter = new SQLiteParameter("@ID", ID),
                            sQLiteParameter1 = new SQLiteParameter("@type", "Facture/" + motif),
                            sQLiteParameter2 = new SQLiteParameter("@date", date),
                            sQLiteParameter3 = new SQLiteParameter("@c_cl", c_cl),
                            sQLiteParameter4 = new SQLiteParameter("@total", amount),
                            sQLiteParameter5 = new SQLiteParameter("@modeReglement", "Cash"),
                            sQLiteParameter6 = new SQLiteParameter("@regler", "0"),
                            sQLiteParameter7 = new SQLiteParameter("@mregler", "0"),
                            sQLiteParameterU = new SQLiteParameter("@user", Properties.Settings.Default.LoggedInUserID + "(" + Properties.Settings.Default.LoggedInUserName + ")"),
                            sQLiteParameterB = new SQLiteParameter("@benefice", "0"),

        sQLiteParameter8 = new SQLiteParameter("@mreste", amount),
                            sQLiteParametertr = new SQLiteParameter("@TR", "0"),
                            sQLiteParameter9 = new SQLiteParameter("@tva", "0");
            sQLiteParameter9 = new SQLiteParameter("@tva", "0");

            SQLiteParameter[] paramms = new SQLiteParameter[] { sQLiteParameter,
                    sQLiteParameter1, sQLiteParameter2,sQLiteParameter3,
                    sQLiteParameter4,sQLiteParameter5,sQLiteParameter6
                ,sQLiteParameter7,sQLiteParameter8,sQLiteParameter9,
                    sQLiteParameterU,sQLiteParametertr,sQLiteParameterB};





            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();


                SQLiteCommand update = new SQLiteCommand(updateRandomInvoice, connection);

                SQLiteCommand insert_ventes = new SQLiteCommand(insertIntoAchat, connection);

                insert_ventes.Parameters.AddRange(paramms);

                using (SQLiteCommand CheckSales = new SQLiteCommand(checkSales, connection))
                {
                    SQLiteDataReader reader = CheckSales.ExecuteReader();
                    reader.Read();
                    int num = reader.GetInt32(0);
                    reader.Close();

                    if (num > 0)
                    {
                        if (update.ExecuteNonQuery() > 0)
                        {

                            connection.Close();
                            return true;
                        }
                        else
                        {
                            connection.Close();
                            return false;
                        }
                    }
                    else
                    {
                        if (insert_ventes.ExecuteNonQuery() > 0)
                        {

                            connection.Close();
                            return true;
                        }
                        else
                        {
                            connection.Close();
                            return false;
                        }
                    }
                }
            }

        }
    }

}

