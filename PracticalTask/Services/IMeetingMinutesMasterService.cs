using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;

namespace PracticalTask.Services;

public interface IMeetingMinutesMasterService : IBaseService<MeetingMinutesMaster, MeetingMinutesMasterVm>
{
    Task<int> InsertMeetingMinutesMasterAsync(
        int? corporateCustomerId,
        int? individualCustomerId,
        DateTime? meetingDate,
        string meetingPlace,
        string attendsFormClientSide,
        string attendsFormHostSide,
        string meetingAgenda,
        string meetingDiscussion,
        string meetingDecision);
}