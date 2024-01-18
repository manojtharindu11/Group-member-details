namespace Groupmemberdetails.Models
{
    public class DetailsRepository
    {
        public static List<Details> _details = new List<Details>()
        {
            new Details {IndexNo = 1, Name="Deepthi", Email="deepthi@gmail.com", Age=22 },
            new Details {IndexNo = 2, Name="Supipi", Email="supipi@gmail.com", Age=25 },
            new Details {IndexNo = 3, Name="Pramudi", Email="parmudi@gmail.com", Age=28 }
        };

        public static List<Details> GetDetails() => _details;

        public static void UpdateDetails(int  index, Details details)
        {
            if (index != details.IndexNo) return;

            var detailsToUpdate = _details.FirstOrDefault(x => x.IndexNo == index);

            if (detailsToUpdate != null)
            {
                detailsToUpdate.Name = details.Name;
                detailsToUpdate.Email = details.Email;
                detailsToUpdate.Age = details.Age;
            }
        }

        public static Details? GetDetailsByIndex(int index)
        {
            var member = _details.FirstOrDefault(x => (x.IndexNo == index));
            if (member != null)
            {
                return new Details
                {
                    IndexNo = member.IndexNo,
                    Name = member.Name,
                    Email = member.Email,
                    Age = member.Age
                };
            }
            return null;

        }

        public static void DeleteMemberByIndex(int index)
        {
            var member = _details.FirstOrDefault(x => (x.IndexNo == index));
            if (member != null)
            {
                _details.Remove(member);
            }
        }

        public static void AddMember(Details details)
        {
            var maxIndex = _details.Max(x => x.IndexNo);
            details.IndexNo = maxIndex + 1;
            _details.Add(details);
        }
    }
}
