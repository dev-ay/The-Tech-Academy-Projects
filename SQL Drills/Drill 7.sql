USE db_music

CREATE TABLE tbl_album (
	album_id INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	album_name VARCHAR(50) NOT NULL,
	album_year INT NOT NULL,
	record_company VARCHAR(50) NOT NULL
);


CREATE TABLE tbl_releases (
	release_id INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	band_name VARCHAR(50) NOT NULL,
	release INT NOT NULL CONSTRAINT fk_album_id FOREIGN KEY REFERENCES tbl_album(album_id) ON UPDATE CASCADE ON DELETE CASCADE
);

INSERT INTO tbl_album 
	(album_name, album_year, record_company)
	VALUES
	('The Weak''s End', '2004', 'Tooth & Nail'),
	('The Question', '2005', 'Tooth & Nail'),
	('Celebrate', '2016', 'Tripple Crown'),
	('Swell', '2018', 'Big Scary Monsters')
;

INSERT INTO tbl_releases
	(band_name, release)
	VALUES
	('Emery', 1),
	('Emery', 1),
	('Tiny Moving Parts', 2),
	('Tiny Moving Parts', 2)
;

SELECT a2.band_name
	FROM tbl_releases a2
	INNER JOIN tbl_album a1 ON a1.album_id = a2.release_id
	WHERE a1.album_year = '2018'
;