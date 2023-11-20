CREATE TABLE contaminants(
	id  SERIAL PRIMARY KEY,
	trip VARCHAR (255),
	longitude REAL,
	latitude REAL,
	datetime TIMESTAMP,
	station VARCHAR (255),
	bottdepthm REAL,
	sampleid VARCHAR (255),
	parameter VARCHAR (255),
	parameter_lv VARCHAR (255),
	tissue VARCHAR (255),
	species VARCHAR (255),
	species_lv VARCHAR (255),
	individuals INTEGER,
	value REAL,
	units VARCHAR (255),
	quality INTEGER
);

comment on column contaminants.trip is 'Universāls paraugu ņemšanas kampaņas kods';
comment on column contaminants.longitude is 'Ģeogrāfiskā Austrumu garuma grādu decimālskaitlis, WGS84 sistēmā';
comment on column contaminants.latitude is 'Ģeogrāfiskā Ziemeļu platuma grādu decimālskaitlis, WGS84 sistēmā';
comment on column contaminants.datetime is 'Paraugu vākšanas datums un laiks';
comment on column contaminants.station is 'Unikāls stacijas kods un/vai nosaukums';
comment on column contaminants.bottdepthm is 'Paraugu ņemšanas stacijas dziļums metros, mērot no ūdens virsmas līdz ūdenstilpes dibenam';
comment on column contaminants.sampleid is 'Unikāls parauga identifikācijas numurs, uz kuru attiecas konkrētā mērījuma vērtība';
comment on column contaminants.parameter is 'Paraugam(-ā) noteiktie parametri (zivju vidējais garums, masa, vecums, ūdens saturs audos, metālu saturs audos)';
comment on column contaminants.parameter_lv is 'Parametra latviskais atšifirējums';
comment on column contaminants.tissue is 'Audi, kuriem(-os) noteikts attiecīgais parametrs - viss (nepreparēts) organisms, akna, muskulis (fileja)';
comment on column contaminants.species is 'Attiecīgā zivju suga - Asaris (Perca fluviatilis), Reņģe (Clupea harengus membras)';
comment on column contaminants.species_lv is 'Zivju sugu latviskais nosaukums';
comment on column contaminants.individuals is 'Vienā paraugā apvienots attiecīgās sugas īpatņu skaits';
comment on column contaminants.value is 'Parauga testēšanā iegūtā parametra vērtība';
comment on column contaminants.units is 'Parametra vērtības mērvienība, DW - vērtība rēķināta uz sausa parauga masu (izžāvētam paraugam); WW - vērtība rēķināta uz mitra parauga masu (nežāvētam paraugam)';
comment on column contaminants.quality is 'Attiecīgās mērījuma vērtības kvalitātes karogs, kas norāda - vai dati ir caurskatīti un pārbaudīti. Atbilstoši SeaDataNet konsorcija kritērijiem';

CREATE INDEX contaminants_parameter_index ON public.contaminants
(
    parameter
);
