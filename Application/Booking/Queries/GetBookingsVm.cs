using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Booking.Queries
{
    public class GetBookingsVm
    {
        public List<BookingItem> BookingList { get; set; }
        public int ItemCount { get; set; }
        public AlertData AlertData { get; set; }
        public GetBookingsVm()
        {
            BookingList = new List<BookingItem>();
            ItemCount = 0;
            AlertData = new AlertData();
        }
    }

    public class AlertData
    {
        public bool ShowAlert { get; set; } 
        public string Tittle { get; set; }
        public string Description { get; set; }
        public string CssClass { get; set; }

        public AlertData()
        {
            ShowAlert = false;
            Description = "Something happen";
            Tittle = "Oops...";
            CssClass = "alert-primary";
        }

        public static AlertData MakeInfoAlert()
        {
            return MakeAlertDataSuccess(BootstrapCssType.Primary, "Data", "Loaded Successfully");
        }

        public static AlertData MakeCreateSuccessAlert()
        {
            return MakeAlertDataSuccess(BootstrapCssType.Success, "Data", "Created Successfully");
        }

        public static AlertData MakeUpdateSuccessAlert()
        {
            return MakeAlertDataSuccess(BootstrapCssType.Success, "Data", "Updated Successfully");
        }

        public static AlertData MakeRemovedDataAlert()
        {
            return MakeAlertDataSuccess(BootstrapCssType.Danger, "Data", "Removed Successfully");
        }

        public static AlertData MakeAlertDataSuccess(BootstrapCssType type, string title, string description)
        {
            AlertData alertData = new AlertData();
            switch (type)
            {
                case BootstrapCssType.Primary:
                    alertData.CssClass = "alert-primary";
                    break;
                case BootstrapCssType.Success:
                    alertData.CssClass = "alert-success";
                    break;
                case BootstrapCssType.Warning:
                    alertData.CssClass = "alert-warning";
                    break;
                case BootstrapCssType.Danger:
                    alertData.CssClass = "alert-danger";
                    break;
            }

            alertData.ShowAlert = true;
            alertData.Tittle = title;
            alertData.Description = description;
            return alertData;
        }
    }


    public enum BootstrapCssType
    {
        Primary,Success,Warning,Danger
    }
}
