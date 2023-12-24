create PROCEDURE GetAllAnimals
AS
BEGIN
    SELECT * FROM Animals;
END;

CREATE TABLE Animals (
    id INT PRIMARY KEY,
    name NVARCHAR(255),
    category NVARCHAR(255),
    color NVARCHAR(255)
);

INSERT INTO Animals (id, name, category, color) VALUES
(1, 'Dog', 'Mammal','Brown'),(2, 'Cat', 'Mammal','Gray'),(3, 'Parrot', 'Bird','Green'),(4, 'Fish', 'Fish','Gold'),(5, 'Snake', 'Reptile','Black');
