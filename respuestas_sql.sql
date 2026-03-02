-- =============================================
-- FastStore - Respuestas SQL
-- =============================================

-- 1. Consulta de Análisis
SELECT 
    p.Nombre AS NombreProducto,
    p.StockActual,
    c.Nombre AS NombreCategoria
FROM Productos p
INNER JOIN Categorias c ON p.CategoriaId = c.Id
WHERE c.Nombre = 'Hogar'
AND p.Precio > 50000;


-- 2. Consulta de Agregación
SELECT 
    c.Nombre AS NombreCategoria,
    CAST(AVG(p.Precio) AS DECIMAL(18,2)) AS PromedioPrecio
FROM Productos p
INNER JOIN Categorias c ON p.CategoriaId = c.Id
GROUP BY c.Nombre;