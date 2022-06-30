namespace MapForms.Models.Units
{
    public class Speed
    {
        public enum SpeedUnits
        {
            /// <summary>Meters per second m/sec</summary>
            mps,
            /// <summary>Miles per hour miles/h</summary>
            mph,
            /// <summary>Kilometrs per hour km/h</summary>
            kmph
        }

        public Speed(double value)
        {
            _value = value;
            _units = SpeedUnits.kmph;
        }

        public Speed(double value, SpeedUnits units)
        {
            _value = value;
            _units = units;
        }

        private double _valueKmph;
        private double _value;
        public double Value { 
            get => _value; 
            set
            {
                _valueKmph = To_kmph(value, _units);
                _value = value; 
            } 
        }

        private SpeedUnits _units;
        public SpeedUnits Units
        {
            get => _units;
            set
            {
                _value = From_kmph(_valueKmph, value);
                _units = value;
            }
        }

        public double ToKmph() => _valueKmph;
        public double ToMph() => From_kmph(_valueKmph, SpeedUnits.mph);
        public double ToMps() => From_kmph(_valueKmph, SpeedUnits.mps);

        public double To_kmph(double value, SpeedUnits units)
        {
            if (units == SpeedUnits.mph)
            {
                return Mph_to_kmph(value);
            }
            else if (units == SpeedUnits.mps)
            {
                return Mps_to_kmph(value);
            }
            return value;
        }

        public double From_kmph(double value, SpeedUnits units)
        {
            if (units == SpeedUnits.mph)
            {
                return Kmph_to_mph(value);
            }
            else if (units == SpeedUnits.mps)
            {
                return Kmph_to_mps(value);
            }
            return value;
        }

        /// <summary>
        /// Function to convert kmph to mps
        /// </summary>
        /// <param name="mph">speed in kilomiters per hour</param>
        /// <returns>speed in meters per second</returns>
        private static double Kmph_to_mps(double kmph)
        {
            return 0.277778 * kmph;
        }

        /// <summary>
        /// Function to convert mps to kmph
        /// </summary>
        /// <param name="mps">speed in meters per second</param>
        /// <returns>speed in kilomiters per hour</returns>
        private static double Mps_to_kmph(double mps)
        {
            return 3.6 * mps;
        }

        /// <summary>
        /// Function to convert kmph to mph
        /// </summary>
        /// <param name="kmph">speed in kilomiters per hour</param>
        /// <returns>speed in miles per hour</returns>
        private static double Kmph_to_mph(double kmph)
        {
            return 0.6213711922 * kmph;
        }

        /// <summary>
        /// Function to convert mph to kmph
        /// </summary>
        /// <param name="mph">speed in miles per hour</param>
        /// <returns>speed in kilomiters per hour</returns>
        private static double Mph_to_kmph(double mph)
        {
            return mph * 1.60934;
        }
    }
}
