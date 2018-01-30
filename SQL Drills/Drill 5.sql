USE [db_zoo]

SELECT 
	a1.species_name AS 'Secies Name:',
	a2.nutrition_type AS 'Nutrition Type:'
	FROM tbl_species a1
	INNER JOIN tbl_nutrition a2 ON a2.nutrition_id = a1.species_nutrition 
;