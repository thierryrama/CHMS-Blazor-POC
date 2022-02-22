using StatCan.Chms.Client.Models;

namespace StatCan.Chms.Client.Services;

public class CycleService
{
    private readonly IEnumerable<Cycle> _cycles = new List<Cycle>()
    {
        new()
        {
            Id = 100,
            Name = "Cycle 8"
        },
        new()
        {
            Id = 200,
            Name = "Cycle 9"
        }
    };

    private readonly IDictionary<int, IEnumerable<Site>> _sitesByCycleId = new Dictionary<int, IEnumerable<Site>>()
    {
        {
            100,
            new List<Site>()
            {
                new()
                {
                    Id = 101,
                    Name = "Halifax",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Atlantic Standard Time;-240;(UTC-04:00) Atlantic Time (Canada);Atlantic Standard Time;Atlantic Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];"),
                },
                new()
                {
                    Id = 102,
                    Name = "Ottawa",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                },
                new()
                {
                    Id = 103,
                    Name = "Vancouver",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Pacific Standard Time;-480;(UTC-08:00) Pacific Time (US & Canada);Pacific Standard Time;Pacific Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                }
            }
        },
        {
            200,
            new List<Site>()
            {
                new()
                {
                    Id = 201,
                    Name = "Halifax",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Atlantic Standard Time;-240;(UTC-04:00) Atlantic Time (Canada);Atlantic Standard Time;Atlantic Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                },
                new()
                {
                    Id = 202,
                    Name = "Edmonton",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Mountain Standard Time;-420;(UTC-07:00) Mountain Time (US & Canada);Mountain Standard Time;Mountain Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                },
                new()
                {
                    Id = 203,
                    Name = "Ottawa",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                },
                new()
                {
                    Id = 204,
                    Name = "Quebec",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Eastern Standard Time;-300;(UTC-05:00) Eastern Time (US & Canada);Eastern Standard Time;Eastern Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                },
                new()
                {
                    Id = 205,
                    Name = "Vancouver",
                    TimeZoneInfo = TimeZoneInfo.FromSerializedString("Pacific Standard Time;-480;(UTC-08:00) Pacific Time (US & Canada);Pacific Standard Time;Pacific Daylight Time;[01:01:0001;12:31:2006;60;[0;02:00:00;4;1;0;];[0;02:00:00;10;5;0;];][01:01:2007;12:31:9999;60;[0;02:00:00;3;2;0;];[0;02:00:00;11;1;0;];];")
                }
            }
        }
    };

    public async Task<IEnumerable<Cycle>> GetCycles()
    {
        return await Task.FromResult(_cycles);
    }

    public async Task<IEnumerable<Site>> GetSitesForCycle(int cycleId)
    {
        var result = _sitesByCycleId.ContainsKey(cycleId) ? _sitesByCycleId[cycleId] : Enumerable.Empty<Site>();
        return await Task.FromResult(result);
    }
}