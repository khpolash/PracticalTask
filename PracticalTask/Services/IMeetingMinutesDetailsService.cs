using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;

namespace PracticalTask.Services;

public interface IMeetingMinutesDetailsService : IBaseService<MeetingMinutesDetails, MeetingMinutesDetailsVm>
{
    Task<int> InsertMeetingMinutesDetailAsync(int? meetingId, int? productId, int? quantity);
}