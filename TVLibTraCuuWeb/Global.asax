<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup        
        string strCon = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"].ToString();
        TruongViet.TVLibTraCuu.Data.cDBase.sqlCn = new System.Data.SqlClient.SqlConnection();
        TruongViet.TVLibTraCuu.Data.cDBase.sqlCn.ConnectionString = strCon;
        try
        {
            TruongViet.TVLibTraCuu.Data.cDBase.sqlCn.Open();
        }
        catch (System.Data.SqlClient.SqlException sqlEx)
        {
        }
        finally { }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        TruongViet.TVLibTraCuu.Data.cDBase.sqlCn.Close();
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        // Session["KhoaID"] = 1;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
