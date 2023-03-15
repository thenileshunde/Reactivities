namespace Domain
{
    public class Activity
    {
        //all the properties need to be public as we are using Entity framework for ORM
        //Entity can be called as model in Entity Framework. The classname relates to table in DB and properties refer to the columns
        //We are going to use an ORM for this mapping - which is Entity framework. This is going to provide us an abstraction away from DB.

        //Normally ORM is used so that we don't need to get into the depths of SQL, PostgresSQL
        //for development purpose we are using sqlite DB. But in production if we want to change our database to prduction worthy
        //technology, ORM makes it easy.
        //with very minimal code changes

        public Guid Id { get; set; }//naming it as id as Entity framework should recognise it as an primary key
        public string Title { get; set; }
        public DateTime Date { get; set; }  
        public string Description { get; set; }     
        public string  Category { get; set; }   
        public string City { get; set; }    
        public string Venue { get; set; }
    
    }
}