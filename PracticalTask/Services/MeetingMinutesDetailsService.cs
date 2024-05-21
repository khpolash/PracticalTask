using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticalTask.DbConnection;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;
using System.Data;

namespace PracticalTask.Services;

public class MeetingMinutesDetailsService : BaseService<MeetingMinutesDetails, MeetingMinutesDetailsVm>, IMeetingMinutesDetailsService
{
    private readonly PracticalTaskDbContext _dbContext;
    public MeetingMinutesDetailsService(PracticalTaskDbContext context, IMapper mapper) : base(context, mapper)
    {
        _dbContext = context;
    }

    public async Task<int> InsertMeetingMinutesDetailAsync(int? meetingId, int? productId, int? quantity)
    {
        var parameters = new[]
        {
            new SqlParameter("@MeetingId", meetingId),
            new SqlParameter("@ProductId", productId),
            new SqlParameter("@Quantity", quantity)
        };

        try
        {
            await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC Meeting_Minutes_Details_Save_SP @MeetingId, @ProductId, @Quantity",
                parameters);

            return 0;
        }
        catch (Exception ex)
        {
            throw new Exception("Error inserting meeting minutes detail.", ex);
        }
    }
}
