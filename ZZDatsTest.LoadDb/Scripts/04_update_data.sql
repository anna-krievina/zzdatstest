CREATE OR REPLACE PROCEDURE update_contaminants_lv_values()
LANGUAGE plpgsql
AS $$
BEGIN
	UPDATE public.contaminants
		SET species_lv='asaris'
		WHERE species='Perch';

	UPDATE public.contaminants
		SET species_lv='siļķes'
		WHERE species='Herrings';

	UPDATE public.contaminants
		SET species_lv='apaļš gobijs'
		WHERE species='Round goby';

	UPDATE public.contaminants
		SET parameter_lv='garums (vidējais)'
		WHERE parameter='lenght (average)';

	UPDATE public.contaminants
		SET parameter_lv='svars (vidējais)'
		WHERE parameter='weight (average)';

	UPDATE public.contaminants
		SET parameter_lv='vecums (vidējais)'
		WHERE parameter='age (average)';

	UPDATE public.contaminants
		SET parameter_lv='ūdens'
		WHERE parameter='H2O';

	UPDATE public.contaminants
		SET parameter_lv='dzīvsudrabs'
		WHERE parameter='Hg';

	UPDATE public.contaminants
		SET parameter_lv='svins'
		WHERE parameter='Pb';

	UPDATE public.contaminants
		SET parameter_lv='kadmijs'
		WHERE parameter='Cd';

	UPDATE public.contaminants
		SET parameter_lv='varš'
		WHERE parameter='Cu';

	UPDATE public.contaminants
		SET parameter_lv='lipīdi'
		WHERE parameter='Lipids';

	UPDATE public.contaminants
		SET parameter_lv='cinks'
		WHERE parameter='Zn';
END; $$