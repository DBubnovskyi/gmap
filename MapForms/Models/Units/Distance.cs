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

        public Distance(double value) :this(value, DistanceUnits.Kilometers) { }

        public Distance(double value, DistanceUnits units)
        {
            _units = units;
            Value = value;
        }

        private double _valueKm;
        private double _value;
        public double Value
        {
            get => _value;
            set
            {
                _valueKm = ToKm(value, _units);
                _value = value;
            }
        }

        private DistanceUnits _units;
        public DistanceUnits Units
        {
            get => _units;
            set
            {
                _value = FromKm(_valueKm, value);
                _units = value;
            }
        }

        public double ToKm() => _valueKm;
        public double ToMiles() => FromKm(_valueKm, DistanceUnits.Miles);
        public double ToMeters() => FromKm(_valueKm, DistanceUnits.Meters);

        public double ToKm(double value, DistanceUnits units)
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

        public double FromKm(DistanceUnits units) => FromKm(_valueKm, units);
        public double FromKm(double value, DistanceUnits units)
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
            return km / 1.6093472187;
        }

        /// <summary>
        /// Function convert km to miles
        /// </summary>
        /// <param name="miles">distance in miles</param>
        /// <returns>distance in kilometers</returns>
        private static double Miles_to_km(double miles)
        {
            return 1.6093472187 * miles;
        }
    }
}
