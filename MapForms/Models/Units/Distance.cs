namespace MapForms.Models.Units
{
    public class Distance
    {
        public enum DistanceUnits
        {
            Meters,
            Kilometers,
            Miles,
        }

        public Distance(double value)
        {
            _value = value;
            _units = DistanceUnits.Kilometers;
        }

        public Distance(double value, DistanceUnits units)
        {
            _value = value;
            _units = units;
        }

        private double _valueKm;
        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                _valueKm = To_km(value, _units);
                _value = value;
            }
        }

        private DistanceUnits _units;
        public DistanceUnits Units
        {
            get => _units;
            set
            {
                _value = From_km(_valueKm, value);
                _units = value;
            }
        }

        public double ToKm() => _valueKm;
        public double ToMiles() => From_km(_valueKm, DistanceUnits.Miles);
        public double ToMeters() => From_km(_valueKm, DistanceUnits.Meters);

        public double To_km(double value, DistanceUnits units)
        {
            if (units == DistanceUnits.Miles)
            {
                return Miles_to_km(value);
            }
            else if (units == DistanceUnits.Meters)
            {
                return value / 1000;
            }
            return value;
        }

        public double From_km(double value, DistanceUnits units)
        {
            if (units == DistanceUnits.Miles)
            {
                return Km_to_miles(value);
            }
            else if (units == DistanceUnits.Meters)
            {
                return value * 1000;
            }
            return value;
        }

        /// <summary>
        /// Function convert km to miles
        /// </summary>
        /// <param name="mp">distance in kilomiters</param>
        /// <returns>distance in miles</returns>
        private static double Km_to_miles(double km)
        {
            return 1.6093472187 * km;
        }

        /// <summary>
        /// Function convert km to miles
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns>distance in kilometers</returns>
        private static double Miles_to_km(double miles)
        {
            return miles / 1.6093472187;
        }
    }
}
