namespace DapperWithCoreExample.Interfaces
{
    public interface ICommandText
    {
        string GetAllPerson { get; }
        string GetPersonByID { get; }
        string AddPerson { get; }
        string UpdatePerson { get; }
        string RemovePerson { get; }
    }

    public class CommandText : ICommandText
    {
        public string GetAllPerson => "Select * from Person where IsDelete=0";

        public string GetPersonByID => "Select * from Person where id=@id";

        public string AddPerson => "Insert into Peson (Id,FirstName,LastName," +
            "Phone,ZipCode,Address,CreateDate,IsDelete) values" +
            "(@Id,@FirstName,@LastName,@Phone,@ZipCode,@Address,@CreateDate,@IsDelete)";

        public string UpdatePerson => "Update Peson Set FirstName=@FirstName,LastName=@LastName" +
            "Phone=@Phone,ZipCode=@ZipCode,Address=@Address,CreateDate=@CreateDate,IsDelete=@IsDelete" +
            "where id=@id";


        public string RemovePerson => "Delete from Peson where id=@id";
    }
}
