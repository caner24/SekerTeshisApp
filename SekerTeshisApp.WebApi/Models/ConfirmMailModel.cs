using SekerTeshis.Core.CrossCuttingConcerns.MailService;

namespace SekerTeshisApp.WebApi.Models
{
    public class ConfirmMailModel
    {
        public string Email { get; set; }

        public string Callback { get; set; }
    }
}
