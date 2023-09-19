namespace EcoDashInnovatorsAPI.Data.Helpers;

public enum EntityType
{
    Partner,
    Client
}

public static class BadgeAssigner
{
    public static List<int> GetBadges(EntityType type, int totalEcoScore, int totalProductEcoScore)
    {
        List<int> badgeIds = new List<int>();

        if (type == EntityType.Partner)
        {
            if (totalEcoScore >= 700 && totalEcoScore <= 799)
                badgeIds.Add(10);
            else if (totalEcoScore >= 800 && totalEcoScore <= 899)
                badgeIds.Add(11);
            else if (totalEcoScore >= 900 && totalEcoScore <= 1000)
                badgeIds.Add(12);

            if (totalProductEcoScore >= 700 && totalProductEcoScore <= 799)
                badgeIds.Add(4);
            else if (totalProductEcoScore >= 800 && totalProductEcoScore <= 899)
                badgeIds.Add(5);
            else if (totalProductEcoScore >= 900 && totalProductEcoScore <= 1000)
                badgeIds.Add(6);
        }
        else if (type == EntityType.Client)
        {
            if (totalEcoScore >= 700 && totalEcoScore <= 799)
                badgeIds.Add(7);
            else if (totalEcoScore >= 800 && totalEcoScore <= 899)
                badgeIds.Add(8);
            else if (totalEcoScore >= 900 && totalEcoScore <= 1000)
                badgeIds.Add(9);

            if (totalProductEcoScore >= 700 && totalProductEcoScore <= 799)
                badgeIds.Add(1);
            else if (totalProductEcoScore >= 800 && totalProductEcoScore <= 899)
                badgeIds.Add(2);
            else if (totalProductEcoScore >= 900 && totalProductEcoScore <= 1000)
                badgeIds.Add(3);
        }

        return badgeIds;
    }
}
