using Cw10Sol.Models;

namespace Cw10Sol.Services
{
    public interface IDbService
    {
        public string retrieveStudents();

        public void changeStd(Student updtStd);

        public void deleteStd(string indexNumber);
        

    }
}