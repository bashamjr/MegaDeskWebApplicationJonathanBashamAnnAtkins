using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaDesk
{
    enum SurfaceMaterial
    {
        oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    };

    /*
    struct DeskStructure
    {
        private decimal width;
        private decimal depth;
        private int numDrawers; //filled from outside the class so use properties to do it
        public SurfaceMaterial finishing;
    };
    */

    class Desk
    {

        //fields
        private const int MAX_WIDTH = 96;       //constant because no need to access outside of class
        private const int MIN_WIDTH = 24;       //constant because no need to access outside of class
        private const int MAX_DEPTH = 48;       //constant because no need to access outside of class
        private const int MIN_DEPTH = 12;       //constant because no need to access outside of class
        private const int MIN_NUM_DRAWERS = 0;  //constant because no need to access outside of class
        private const int MAX_NUM_DRAWERS = 7;  //constant because no need to access outside of class
        private const decimal BASE_PRICE = 200M; //constant because no need to access outside of class
        private string surfaceFinishing;
        private decimal width;
        private decimal depth;
        private int numDrawers; //filled from outside the class so use properties to do it
        public SurfaceMaterial finishing;
        //public  DeskStructure deskFields; I don't want to deal with structures within a class so I commented this section out


        //Properties
        public decimal Depth
        {
            get { return depth; }
            set
            {
                if (value >= MIN_DEPTH && value <= MAX_DEPTH)
                {
                    depth = value;
                }
                else if (value < MIN_DEPTH)
                {

                    depth = MIN_DEPTH;
                    // MessageBox.Show("Now using MIN_Depth");

                }
                else if (value > MAX_DEPTH)
                {

                    depth = MAX_DEPTH;
                    //MessageBox.Show("Now using MAX_Depth");

                }

            }
        }

        public decimal ReturnBasePrice()
        {
            return BASE_PRICE;
        }


        public decimal Width
        {
            get { return width; }
            set
            {
                if (value >= MIN_WIDTH && value <= MAX_WIDTH)
                {
                    width = value;
                }
                else if (value >= MAX_WIDTH)
                {
                    width = MAX_WIDTH;

                }

                else if (value <= MIN_WIDTH)
                {
                    width = MIN_WIDTH;


                }
            }
        }

        public int NumDrawers
        {
            get { return numDrawers; }
            set
            {
                if (value >= MIN_NUM_DRAWERS && value <= MAX_NUM_DRAWERS)
                {
                    numDrawers = value;
                }
                else if (value >= MAX_NUM_DRAWERS)
                {
                    width = MAX_NUM_DRAWERS;

                }

                else if (value <= MIN_NUM_DRAWERS)
                {
                    width = MIN_NUM_DRAWERS;


                }


            }
        }

        public string SurfaceFinishing { get => surfaceFinishing; set => surfaceFinishing = value; }

        //methods
        //constructors
        public Desk()
        {


        }

        public Desk(int width, int depth, int numDrawers, SurfaceMaterial surfMaterial)
        {
            //by sticking the user input into the constructor for the properties to use, the 
            //  setters can do the validations and ensure that the constructors are properly creating an object.
            Width = width;
            Depth = depth;
            NumDrawers = numDrawers;
            finishing = surfMaterial;


        }

        ~Desk()
        {
        }


    }
}