using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        // it will update the complete orderHeader, based on the Id we want to update the order status Or payment status
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus , string? paymentStatus = null );
		//PaymentSataus once it approved it stays approved so OrderStatus req but PaymentSataus can be null

		void UpdateStripePaymentID(int id, string sessionId, string? paymentIntentId);

	}
}

