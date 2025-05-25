
---

# 🌍 `SimpleGeoFiltering` – Full & Updated Documentation

---

## 📦 Package Purpose

`SimpleGeoFiltering` allows you to **filter places by location**, with **optional filters** like:

* 📍 Radius
* 🗺️ Country / Region
* 🏷️ Tags (in Arabic or English)
* 🔠 Partial Name Match (NEW ✅)

It returns places with Google Maps links and localized distances (e.g. `3.50 km` / `٣٫٥٠ كم`).

---

## 🛠️ Installation

Install the package via NuGet:

```bash
Install-Package SimpleGeoFiltering
```

---

## ⚙️ Configuration

Register the service in `Program.cs`:

```csharp
builder.Services.AddSimpleGeoFiltering();
```

Now the service can be injected using **Dependency Injection**.

---

## 💉 Dependency Injection

Inject the service where needed:

```csharp
private readonly IGeoFilterService _geoFilterService;

public YourControllerOrClass(IGeoFilterService geoFilterService)
{
    _geoFilterService = geoFilterService;
}
```

---

## 🔁 Flow Overview

Let’s say your user is standing in **Amman, Jordan**, and you want to find nearby places:

---

### 🔹 1. Prepare User Location

```csharp
var userLocation = new GeoPoint
{
    Latitude = 31.9539,
    Longitude = 35.9106
};
```

---

### 🔹 2. Prepare List of Places

```csharp
var yourListOfPlaces = new List<GeoPoint>
{
    new()
    {
        Name = "Amman Citadel",
        Latitude = 31.9519,
        Longitude = 35.9345,
        Country = "Jordan",
        Region = "Amman",
        Tags = new List<string> { "tourism", "history" }
    },
    new()
    {
        Name = "Dead Sea",
        Latitude = 31.5590,
        Longitude = 35.4732,
        Country = "Jordan",
        Region = "Amman",
        Tags = new List<string> { "tourism", "nature" }
    },
    new()
    {
        Name = "قلعة عمان",
        Latitude = 31.9519,
        Longitude = 35.9345,
        Country = "Jordan",
        Region = "Amman",
        Tags = new List<string> { "سياحة", "تاريخ" }
    }
};
```

---

### 🔹 3. Call Filtering Method

With full filters:

```csharp
var results = _geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Kilometers,
    country: "Jordan",
    region: "Amman",
    tags: new List<string> { "tourism", "سياحة" },
    name: "Citadel"
);
```

Only by radius (NEW):

```csharp
var results = _geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Kilometers
);
```

Search by name only (NEW):

```csharp
var results = _geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Kilometers,
    name: "قلعة"
);
```

---

## 📥 JSON Input Example

```json
{
  "center": {
    "latitude": 31.9539,
    "longitude": 35.9106
  },
  "points": [
    {
      "name": "Amman Citadel",
      "latitude": 31.9519,
      "longitude": 35.9345,
      "country": "Jordan",
      "region": "Amman",
      "tags": ["tourism", "history"]
    },
    {
      "name": "Dead Sea",
      "latitude": 31.5590,
      "longitude": 35.4732,
      "country": "Jordan",
      "region": "Amman",
      "tags": ["tourism", "nature"]
    },
    {
      "name": "قلعة عمان",
      "latitude": 31.9519,
      "longitude": 35.9345,
      "country": "Jordan",
      "region": "Amman",
      "tags": ["سياحة", "تاريخ"]
    }
  ],
  "radiusKm": 10,
  "country": "Jordan",
  "region": "Amman",
  "tags": ["tourism", "سياحة"],
  "name": "قلعة",
  "displayUnit": "Kilometers"
}
```

---

## 📤 JSON Output Example

```json
[
  {
    "name": "Amman Citadel",
    "latitude": 31.9519,
    "longitude": 35.9345,
    "country": "Jordan",
    "region": "Amman",
    "tags": ["tourism", "history"],
    "mapUrl": "https://www.google.com/maps?q=31.9519,35.9345",
    "formattedDistance": "2.30 km"
  },
  {
    "name": "قلعة عمان",
    "latitude": 31.9519,
    "longitude": 35.9345,
    "country": "Jordan",
    "region": "Amman",
    "tags": ["سياحة", "تاريخ"],
    "mapUrl": "https://www.google.com/maps?q=31.9519,35.9345",
    "formattedDistance": "٢٫٣٠ كم"
  }
]
```

---

## 📦 DTOs

```csharp
public class FilterRequest
{
    public GeoPoint Center { get; set; } = new GeoPoint();
    public List<GeoPoint> Points { get; set; } = new List<GeoPoint>();
    public double RadiusKm { get; set; }
    public string? Country { get; set; }
    public string? Region { get; set; }
    public List<string>? Tags { get; set; }
    public string? Name { get; set; } // ✅ NEW
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DistanceUnit DisplayUnit { get; set; }
}
```

---

## ✅ Key Features

| Feature             | Description                                      |
| ------------------- | ------------------------------------------------ |
| 📍 Radius Filtering | Required distance logic (km, m, miles, nautical) |
| 🏙️ Country/Region  | Optional filters                                 |
| 🏷️ Tags            | Arabic & English supported                       |
| 🔠 Name Matching    | ✅ NEW – Partial search support                   |
| 🌍 Map URLs         | Clean Google Maps links                          |
| 🌐 Localized Output | Supports both Arabic & English                   |

---


