namespace SharpShootersRemix_Nudgd_SheetData.Models
{
    public class SheetRow
    {
        // alla är lagda som string till en början
        // men kanske kommer behöva ändras till DateOnly/Time, int och lists osv
        public string DATA_TYPE { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Signed_Date { get; set; }
        public string Start_Date { get; set; }
        public string End_Date { get; set; }
        public string Vertical { get; set; }
        public string Project_Type { get; set; }
        public string Time_to_close { get; set; }
        public string Time_in_project { get; set; }
        public string Project_Milestones { get; set; }
        public string Budget_SEK { get; set; }
        public string Budget_h { get; set; }
        public string Client_Cost { get; set; }
    }
}
