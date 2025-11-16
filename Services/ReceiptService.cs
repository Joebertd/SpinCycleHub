using SpinCycleHub.Models;
using System.Text;

namespace SpinCycleHub.Services
{
    public class ReceiptService
    {
        public string GenerateReceiptText(Transaction trx)
        {
            var sb = new StringBuilder();
            sb.AppendLine("====================================");
            sb.AppendLine("       SPIN CYCLE LAUNDRY HUB");
            sb.AppendLine("====================================");
            sb.AppendLine($"Transaction ID : {trx.Id}");
            sb.AppendLine($"Date           : {trx.CreatedAt:MMM dd yyyy hh:mm tt}");
            sb.AppendLine("------------------------------------");
            sb.AppendLine($"Service        : {trx.Service?.ServiceName}");
            sb.AppendLine($"Weight (kg)    : {trx.Weight}");
            sb.AppendLine($"Price          : ₱{trx.Price:N2}");
            sb.AppendLine($"TOTAL          : ₱{trx.Total:N2}");
            sb.AppendLine("------------------------------------");
            sb.AppendLine($"Payment Mode   : {trx.PaymentMode}");
            if (trx.PaymentMode == "GCash")
            {
                sb.AppendLine($"GCash Ref      : {trx.GCashRef}");
                sb.AppendLine($"Paid Amount    : ₱{trx.GCashAmount:N2}");
            }
            sb.AppendLine("------------------------------------");
            sb.AppendLine("      THANK YOU FOR YOUR TRUST!");
            sb.AppendLine("====================================");
            return sb.ToString();
        }
    }
}
