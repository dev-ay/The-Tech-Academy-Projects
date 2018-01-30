USE [db_zoo]

SELECT 
	a1.specialist_fname, a1.specialist_lname, a1.specialist_contact
	FROM tbl_specialist a1
	INNER JOIN tbl_care a2 ON a2.care_specialist = a1.specialist_id
	INNER JOIN tbl_species a3 ON a3.species_care = a2.care_id
	WHERE a3.species_name = 'penguin'
;