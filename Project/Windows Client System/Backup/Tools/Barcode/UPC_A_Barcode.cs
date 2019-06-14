using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BinarySoftCo.Tools.Barcode
{
	public class UPC_A_Barcode
    {
        #region Variables

		private float _fMinimumAllowableScale = .8f;
		private float _fMaximumAllowableScale = 2.0f;

		// This is the nomimal size recommended by the UCC.
		private float _fWidth = 1.469f;
		private float _fHeight = 1.02f;
		private float _fFontSize = 8.0f;
		private float _fScale = 1.0f;

		// Left Hand Digits.
		private string [] _aLeft = { "0001101", "0011001", "0010011", "0111101", 
									 "0100011", "0110001", "0101111", "0111011", 
									 "0110111", "0001011" };

			// Right Hand Digits.
		private string [] _aRight = { "1110010", "1100110", "1101100", "1000010", 
									  "1011100", "1001110", "1010000", "1000100", 
									  "1001000", "1110100" };

		private string _sQuiteZone = "0000000000";

		private string _sLeadTail = "101";

		private string _sSeparator = "01010";

		private string _sProductType = "0";
		private string _sManufacturerCode;
		private string _sProductCode;
		private string _sChecksumDigit;

        #endregion

        #region Properties

        public float MinimumAllowableScale
        {
            get
            {
                return _fMinimumAllowableScale;
            }
        }

        public float MaximumAllowableScale
        {
            get
            {
                return _fMaximumAllowableScale;
            }
        }

        public float Width
        {
            get
            {
                return _fWidth;
            }
        }

        public float Height
        {
            get
            {
                return _fHeight;
            }
        }

        public float FontSize
        {
            get
            {
                return _fFontSize;
            }
        }

        public float Scale
        {
            get
            {
                return _fScale;
            }

            set
            {
                if (value < this._fMinimumAllowableScale || value > this._fMaximumAllowableScale)
                    throw new Exception("Scale value out of allowable range.  Value must be between " +
                                        this._fMinimumAllowableScale.ToString() + " and " +
                                        this._fMaximumAllowableScale.ToString());
                _fScale = value;
            }
        }

        /// <summary>
        /// System Description 
        /// 0 - Regular UPC codes 
        /// 1 - Reserved 
        /// 2 - Weightitems marked at the store 
        /// 3 - National Drug/Health-related code 
        /// 4 - No format restrictions, in-store use on non-food items 
        /// 5 - Coupons 
        /// 6 - Reserved 
        /// 7 - Regular UPC codes 
        /// 8 - Reserved 
        /// 9 - Reserved 
        /// </summary>
        /// <value></value>
        public string ProductType
        {
            get
            {
                return _sProductType;
            }

            set
            {
                // Check against what types are valid.
                int iTemp = Convert.ToInt32(value);
                if (iTemp == 1 || iTemp == 6 || iTemp > 7)
                    throw new Exception(value + " is a reserved Product Type. ");

                _sProductType = value;
            }
        }

        public string ManufacturerCode
        {
            get
            {
                return _sManufacturerCode;
            }

            set
            {
                if (value.Length != 5)
                    throw new Exception("The manufacturer number must be 5 digits.");
                _sManufacturerCode = value;
            }
        }

        public string ProductCode
        {
            get
            {
                return _sProductCode;
            }

            set
            {
                if (value.Length != 5)
                    throw new Exception("The product identification number must be 5 digits.");

                _sProductCode = value;
            }
        }

        public string ChecksumDigit
        {
            get
            {
                return _sChecksumDigit;
            }

            set
            {
                int iValue = Convert.ToInt32(value);
                if (iValue < 0 || iValue > 9)
                    throw new Exception("The Check Digit must be between 0 and 9.");
                _sChecksumDigit = value;
            }
        }

        #endregion Properties

        #region Private Methods

        private string ConvertToDigitPatterns(string inputNumber, string[] patterns)
        {
            StringBuilder sbTemp = new StringBuilder();
            int iIndex = 0;
            for (int i = 0; i < inputNumber.Length; i++)
            {
                iIndex = Convert.ToInt32(inputNumber.Substring(i, 1));
                sbTemp.Append(patterns[iIndex]);
            }
            return sbTemp.ToString();
        }

        public void CalculateChecksumDigit()
        {
            string sTemp = this.ProductType + this.ManufacturerCode + this.ProductCode;
            int iSum = 0;
            int iDigit = 0;

            // Calculate the checksum digit here.
            for (int i = 1; i <= sTemp.Length; i++)
            {
                iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                if (i % 2 == 0)
                {	// even
                    iSum += iDigit * 1;
                }
                else
                {	// odd
                    iSum += iDigit * 3;
                }
            }

            int iCheckSum = (10 - (iSum % 10)) % 10;
            this.ChecksumDigit = iCheckSum.ToString();

        }

        #endregion

        #region Public Methods

        public void DrawBarcode(Graphics Graphic, Point Point)
        {
            float width = this.Width * this.Scale;
            float height = this.Height * this.Scale;

            // A upc-a excluding 2 or 5 digit supplement information 
            //	should be a total of 113 modules wide. Supplement information is typically 
            //	used for periodicals and books.
            float lineWidth = width / 113f;

            // Save the GraphicsState.
            GraphicsState gs = Graphic.Save();

            // Set the PageUnit to Inch because all of our measurements are in inches.
            Graphic.PageUnit = GraphicsUnit.Inch;

            // Set the PageScale to 1, so an inch will represent a true inch.
            Graphic.PageScale = 1;

            SolidBrush brush = new SolidBrush(Color.Black);

            float xPosition = 0;

            StringBuilder strbUPC = new StringBuilder();

            float xStart = Point.X;
            float yStart = Point.Y;
            float xEnd = 0;

            Font font = new Font("Arial", this._fFontSize * this.Scale);

            // Calculate the Check Digit.
            this.CalculateChecksumDigit();

            // Build the UPC Code.
            strbUPC.AppendFormat("{0}{1}{2}{3}{4}{5}{6}{1}{0}",
                                    this._sQuiteZone, this._sLeadTail,
                                    ConvertToDigitPatterns(this.ProductType, this._aLeft),
                                    ConvertToDigitPatterns(this.ManufacturerCode, this._aLeft),
                                    this._sSeparator,
                                    ConvertToDigitPatterns(this.ProductCode, this._aRight),
                                    ConvertToDigitPatterns(this.ChecksumDigit, this._aRight));

            string sTempUPC = strbUPC.ToString();

            float fTextHeight = Graphic.MeasureString(sTempUPC, font).Height;

            // Draw the barcode lines.
            for (int i = 0; i < strbUPC.Length; i++)
            {
                if (sTempUPC.Substring(i, 1) == "1")
                {
                    if (xStart == Point.X)
                        xStart = xPosition;

                    // Save room for the UPC number below the bar code.
                    if ((i > 19 && i < 56) || (i > 59 && i < 95))
                        // Draw space for the number
                        Graphic.FillRectangle(brush, xPosition, yStart, lineWidth, height - fTextHeight);
                    else
                        // Draw a full line.
                        Graphic.FillRectangle(brush, xPosition, yStart, lineWidth, height);
                }

                xPosition += lineWidth;
                xEnd = xPosition;
            }

            // Draw the upc numbers below the line.

            xPosition = xStart - Graphic.MeasureString(this.ProductType, font).Width;
            float yPosition = yStart + (height - fTextHeight);
            // Draw Product Type.
            Graphic.DrawString(this.ProductType, font, brush, new PointF(xPosition, yPosition));

            // Each digit is 7 modules wide, therefore the MFG_Number is 5 digits wide so
            //    5 * 7 = 35, then add 3 for the LeadTrailer Info and another 7 for good measure,
            //    that is where the 45 comes from.
            xPosition += Graphic.MeasureString(this.ProductType, font).Width + 45 * lineWidth -
                            Graphic.MeasureString(this.ManufacturerCode, font).Width;

            // Draw MFG Number.
            Graphic.DrawString(this.ManufacturerCode, font, brush, new PointF(xPosition, yPosition));

            // Add the width of the MFG Number and 5 modules for the separator.
            xPosition += Graphic.MeasureString(this.ManufacturerCode, font).Width +
                         5 * lineWidth;

            // Draw Product ID.
            Graphic.DrawString(this.ProductCode, font, brush, new PointF(xPosition, yPosition));

            // Each digit is 7 modules wide, therefore the Product Id is 5 digits wide so
            //    5 * 7 = 35, then add 3 for the LeadTrailer Info, + 8 more just for spacing
            //  that is where the 46 comes from.
            xPosition += 46 * lineWidth;

            // Draw Check Digit.
            Graphic.DrawString(this.ChecksumDigit, font, brush, new PointF(xPosition, yPosition));

            // Restore the GraphicsState.
            Graphic.Restore(gs);
        }

        public Bitmap CreateBitmap()
        {
            float tempWidth = (this.Width * this.Scale) * 100;
            float tempHeight = (this.Height * this.Scale) * 100;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap((int)tempWidth, (int)tempHeight);

            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);

            this.DrawBarcode(g, new System.Drawing.Point(0, 0));

            g.Dispose();

            return bmp;
        }

        #endregion

        #region Constructor

        public UPC_A_Barcode( )
		{
            this.ProductType = "0";
		}

        public UPC_A_Barcode(string ManufacturerCode, string ProductCode)
            : this()
		{
            this.ManufacturerCode = ManufacturerCode;
            this.ProductCode = ProductCode;
            //
			this.CalculateChecksumDigit( );
		}

        public UPC_A_Barcode(string ProductType, string ManufacturerCode, string ProductCode)
            : this(ManufacturerCode, ProductCode)
        {
            this.ProductType = ProductType;
            //
            this.CalculateChecksumDigit();
        }

        public UPC_A_Barcode(string ProductType, string ManufacturerCode, string ProductCode, string ChecksumDigit)
            : this(ProductType, ManufacturerCode, ProductCode)
        {
            this.ChecksumDigit = ChecksumDigit;
        }

        #endregion
	}
}