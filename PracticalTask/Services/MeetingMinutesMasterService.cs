using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticalTask.DbConnection;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;
using System.Data;

namespace PracticalTask.Services;

public class MeetingMinutesMasterService : BaseService<MeetingMinutesMaster, MeetingMinutesMasterVm>, IMeetingMinutesMasterService
{
    private readonly PracticalTaskDbContext _dbContext;
    public MeetingMinutesMasterService(PracticalTaskDbContext context, IMapper mapper) : base(context, mapper)
    {
        _dbContext = context;
    }

    public async Task<int> InsertMeetingMinutesMasterAsync(
        int? corporateCustomerId,
        int? individualCustomerId,
        DateTime? meetingDate,
        string meetingPlace,
        string attendsFormClientSide,
        string attendsFormHostSide,
        string meetingAgenda,
        string meetingDiscussion,
        string meetingDecision)
    {
        var parameters = new[]
        {
            new SqlParameter("@CorporateCustomerId", corporateCustomerId ?? (object)DBNull.Value),
            new SqlParameter("@IndividualCustomerId", individualCustomerId ?? (object)DBNull.Value),
            new SqlParameter("@MeetingDate", meetingDate),
            new SqlParameter("@MeetingPlace", meetingPlace ?? (object)DBNull.Value),
            new SqlParameter("@AttendsFormClientSide", attendsFormClientSide ?? (object)DBNull.Value),
            new SqlParameter("@AttendsFormHostSide", attendsFormHostSide ?? (object)DBNull.Value),
            new SqlParameter("@MeetingAgenda", meetingAgenda ?? (object)DBNull.Value),
            new SqlParameter("@MeetingDiscussion", meetingDiscussion ?? (object)DBNull.Value),
            new SqlParameter("@MeetingDecision", meetingDecision ?? (object)DBNull.Value),
            new SqlParameter
            {
                ParameterName = "@NewId",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            }
        };

        try
        {
            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC Meeting_Minutes_Master_Save_SP @CorporateCustomerId, @IndividualCustomerId, @MeetingDate, @MeetingPlace, @AttendsFormClientSide, @AttendsFormHostSide, @MeetingAgenda, @MeetingDiscussion, @MeetingDecision, @NewId OUTPUT", parameters);

            return (int)parameters[9].Value;
        }
        catch (Exception ex)
        {
            throw new Exception("Error inserting meeting minutes master.", ex);
        }
    }
}
