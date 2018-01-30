USE [db_zoo]

SELECT 
	species_name
	FROM tbl_species a1
	INNER JOIN tbl_nutrition a2 ON a2.nutrition_id = a1.species_nutrition 
	WHERE nutrition_id < 2206 AND nutrition_id > 2202
;