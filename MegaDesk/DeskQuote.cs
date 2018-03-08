using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaDesk
{
    class DeskQuote
    {
        //fields
        public decimal price;
        public string surfaceMaterialOption;
        public string customerName;
        public int rushOption;
        public decimal extraDeskCost;
        DateTime quoteDate = DateTime.Now;
        public List<DeskQuote> myList = new List<DeskQuote>();
        public Desk desk = new Desk(); //it seems that when one has an object as a member field of another class, one must initialise the member object with memory
                                       //or one gets a NULL reference error

        //properties
        public string CustomerName
        {
            get { return customerName; }
            set
            {
                if (value != "")
                {
                    customerName = value;
                }
                else
                {
                    throw new Exception("Name field cannot be empty.");
                }
            }

        }
        /// <summary>
        /// Rush option property
        /// </summary>
        public int RushOption
        {
            get { return rushOption; }
            set
            {
                if (value == 3 || value == 5 || value == 7)
                {
                    rushOption = value;
                }
                /* else
                 {
                     throw new Exception("Enter the number 3, 5 or 7"); 
                 }*/

            }

        }

        public string SurfaceMaterialOption
        {
            get => surfaceMaterialOption;
            set => surfaceMaterialOption = value;
        }
        internal List<DeskQuote> MyList { get => myList; set => myList = value; }
        public decimal Price { get => price; set => price = value; }



        //methods

        /// <summary>
        /// Default constructor
        /// </summary>
        public DeskQuote()
        {

        }

        /// <summary>
        /// Non-default constructor
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="rushOption"></param>
        /// <param name="deskPassed"></param>
        public DeskQuote(string customerName, int rushOption, Desk deskPassed)
        {


            CustomerName = customerName;
            RushOption = rushOption;
            desk.Depth = deskPassed.Depth;
            desk.Width = deskPassed.Width;
            desk.NumDrawers = deskPassed.NumDrawers;
            desk.finishing = deskPassed.finishing;


        }



        /// <summary>
        /// calculateRushOption
        /// </summary>
        /// <param name="rushOption"></param>
        /// <returns></returns>
        public int CalculateRushOrderCost(int rushOption)
        {
            int rushOrderCost = 0;

            switch (rushOption)
            {
                case 3:
                    if (desk.Depth * desk.Width < 1000)
                        rushOrderCost = 60;
                    else if (desk.Depth * desk.Width >= 1000 && desk.Depth * desk.Width < 2000)
                        rushOrderCost = 70;
                    else if (desk.Depth * desk.Width >= 2000)
                        rushOrderCost = 80;
                    break;
                case 5:
                    if (desk.Depth * desk.Width < 1000)
                        rushOrderCost = 40;
                    else if (desk.Depth * desk.Width >= 1000 && desk.Depth * desk.Width < 2000)
                        rushOrderCost = 50;
                    else if (desk.Depth * desk.Width >= 2000)
                        rushOrderCost = 60;
                    break;
                case 7:
                    if (desk.Depth * desk.Width < 1000)
                        rushOrderCost = 30;
                    else if (desk.Depth * desk.Width >= 1000 && desk.Depth * desk.Width < 2000)
                        rushOrderCost = 35;
                    else if (desk.Depth * desk.Width >= 2000)
                        rushOrderCost = 40;
                    break;
                default:
                    break;

            }

            return rushOrderCost;
        }


        /// <summary>
        /// Calculate surface material Cost
        /// </summary>
        /// 
        public decimal calclateSurfaceMaterialcost()
        {
            decimal sMCost = 0M;
            if (desk.finishing == SurfaceMaterial.oak)
            {
                sMCost = 0M;
            }



            return sMCost;

        }

        /// <summary>
        /// Calculate total desk price
        /// </summary>
        /// 
        public decimal CalcDeskPrice()
        {
            decimal price = 0M;


            decimal sizeOfDesk = desk.Width * desk.Depth;
            if (sizeOfDesk > 1000)
            {

                extraDeskCost = (sizeOfDesk - 1000M) * 1;
            }
            else
            {
                extraDeskCost = 0M;
            }

            price = extraDeskCost
                    + desk.ReturnBasePrice()
                    + (decimal)CalculateRushOrderCost(rushOption)
                    + calclateSurfaceMaterialcost()
                    + (decimal)(desk.NumDrawers * 50);
            return price;

        }




        public void ViewQuote()
        {




        }


        public void GetTime()
        {

        }





    }
}