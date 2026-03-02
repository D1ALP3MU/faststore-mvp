# 🛒 FastStore – Sistema de Control de Quiebre de Stock (MVP)

## 📌 Descripción

FastStore es una herramienta mínima viable (MVP) que permite al personal de bodega identificar productos con stock crítico y generar órdenes de reposición de forma rápida.

El sistema está compuesto por:

* 🔹 Backend: API REST en .NET 8 con Entity Framework Core
* 🔹 Frontend: SPA en Angular
* 🔹 Base de datos: SQL Server

---

## 🧱 Arquitectura

El backend sigue una arquitectura por capas:

```
Controllers → Services → Data (DbContext) → SQL Server
```

Además, se implementan **DTOs** para evitar referencias circulares y optimizar la respuesta al frontend.

---

## 🚀 Tecnologías utilizadas

### Backend

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server Express

### Frontend

* Angular 21
* TypeScript
* HTML5 / SCSS

### Base de Datos

* SQL Server
* T-SQL

---

## 📂 Estructura del proyecto

```
faststore-mvp/
├── Controllers/
├── Services/
├── Models/
├── DTOs/
├── Data/
├── frontend/
├── respuestas_sql.sql
└── README.md
```

---

## ⚙️ Configuración del Backend

### 1️⃣ Clonar el repositorio

```bash
git clone https://github.com/D1ALP3MU/faststore-mvp.git
cd faststore-mvp
```
> 💡 Repositorio público para evaluación técnica.

### 2️⃣ Configurar cadena de conexión

Editar en:

```
appsettings.json
```

Actualizar:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=FastStoreDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```
> ⚠️ Ajustar el Connection String según el entorno local.

---

### 3️⃣ Restaurar dependencias

```bash
dotnet restore
```

### 4️⃣ Aplicar migraciones (si aplica)

```bash
dotnet ef database update
```

### 5️⃣ Ejecutar API

```bash
dotnet run
```

La API quedará disponible en:

```
http://localhost:5081/swagger
```

---

## 🖥️ Configuración del Frontend

### 1️⃣ Ir a la carpeta frontend

```bash
cd frontend
```

### 2️⃣ Instalar dependencias

```bash
npm install
```

### 3️⃣ Ejecutar la aplicación

```bash
ng serve
```

Disponible en:

```
http://localhost:4200
```

---

## 🔌 Endpoints implementados

### ✅ GET /api/inventory

Lista todos los productos con su categoría.

### ✅ GET /api/inventory/low-stock

Retorna productos con stock crítico:

```
StockActual < StockMinimo
```

### ✅ POST /api/orders

Crea una nueva orden de reposición.

**Regla de negocio:**
No permite cantidades ≤ 0.

---

## 🧪 Validaciones implementadas

* ✔ Validación de cantidad > 0 en backend
* ✔ Validación de producto existente
* ✔ Validación de stock crítico antes de crear orden
* ✔ Validación básica en frontend para evitar envíos vacíos

---

## 🗄️ Consultas SQL

El archivo:

```
respuestas_sql.sql
```

contiene:

1. Consulta de análisis por categoría y precio
2. Consulta de agregación (promedio por categoría)

---

## ✅ Criterios de aceptación cumplidos

* ✔ Funcionalidad completa end-to-end
* ✔ Arquitectura por capas clara
* ✔ Uso de DTOs para respuestas limpias
* ✔ Persistencia correcta en SQL Server
* ✔ Validaciones básicas en frontend y backend
* ✔ Proyecto ejecutable con npm install y dotnet run

---

## 👨‍💻 Autor

**Diego Pérez**
---
