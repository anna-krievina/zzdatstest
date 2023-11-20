CREATE MATERIALIZED VIEW metals_in_species
AS
 SELECT parameter_lv, SUM(individuals) as individuals, species_lv, SUM(value) as value, units
	FROM public.contaminants as cont 
	WHERE parameter in ('Hg', 'Pb', 'Cd', 'Cu', 'Zn') 
	GROUP BY species, species_lv, units, parameter, parameter_lv
	ORDER BY species, value desc;

CREATE MATERIALIZED VIEW parameters_in_years
AS
	SELECT date_trunc('year', datetime) AS datetime, parameter_lv, AVG(value) as value, units
	FROM public.contaminants
	GROUP BY date_trunc('year', datetime), parameter_lv, units
	ORDER BY datetime desc, parameter_lv;
	
	
CREATE OR REPLACE FUNCTION get_metals_in_species() 
	RETURNS TABLE (
		parameter_lv VARCHAR,
		individuals INT,
		species_lv VARCHAR,
		value REAL,
		units VARCHAR 
	)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY SELECT cont.parameter_lv, SUM(cont.individuals) as individuals, cont.species_lv, SUM(cont.value) as value, cont.units
	FROM public.contaminants as cont where parameter in ('Hg', 'Pb', 'Cd', 'Cu', 'Zn') 
	GROUP BY species, species_lv, units, parameter, parameter_lv
	ORDER BY species, sum desc;
END; $$