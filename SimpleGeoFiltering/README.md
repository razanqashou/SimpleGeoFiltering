
All versions of this package, including earlier releases, are licensed under the MIT License. See LICENSE.txt for details.

---

# 🌍 `SimpleGeoFiltering` – Full Updated Documentation

---

## 📦 Package Purpose

`SimpleGeoFiltering` is used to **filter places by geographic distance**, with support for optional filters:

| Feature               | Description                                               |
| --------------------- | --------------------------------------------------------- |
| 📍 Radius Filtering   | Required – supports km, meters, miles, and nautical miles |
| 🏙️ Country/Region    | Optional – filters by country or region                   |
| 🏷️ Tags              | Optional – Arabic & English tags supported                |
| 🔠 Partial Name Match | Optional – supports partial text search (in any language) |
| 🌐 Localized Output   | Google Maps links and localized distance formatting       |

---

## 🛠️ Installation

Install via NuGet:

```bash
Install-Package SimpleGeoFiltering
```

---

## ⚙️ Configuration

In `Program.cs`:

```csharp
builder.Services.AddSimpleGeoFiltering();
```

---

## 💉 Dependency Injection

Inject it into your class or controller:

```csharp
private readonly IGeoFilterService _geoFilterService;

public YourClass(IGeoFilterService geoFilterService)
{
    _geoFilterService = geoFilterService;
}
```

---

## 🔁 Flow Overview

Example: user is in **Amman, Jordan**, and wants to find places nearby.

---

### 🔹 1. User Location

```csharp
var userLocation = new GeoPoint
{
    Latitude = 31.9539,
    Longitude = 35.9106
};
```

---

### 🔹 2. List of Places

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

### 🔹 3. Use the Filtering Method

```csharp
var results = _geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Kilometers,
    country: "Jordan",
    region: "Amman",
    tags: new List<string> { "tourism", "سياحة" },
    name: "قلعة"
);
```

**Or: just radius filter (NEW):**

```csharp
_geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Miles
);
```

**Or: just name search (NEW):**

```csharp
_geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Meters,
    name: "Citadel"
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
    public string? Name { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DistanceUnit DisplayUnit { get; set; }
}
```

```csharp
public enum DistanceUnit
{
    Kilometers,
    Meters,
    Miles,
    NauticalMiles
}
```

---

## ✅ Summary of Features

| Feature               | Status | Notes                                       |
| --------------------- | ------ | ------------------------------------------- |
| 📍 Radius             | ✅      | Required                                    |
| 🏙 Country / Region   | ✅      | Optional                                    |
| 🏷 Tags (EN + AR)     | ✅      | Optional                                    |
| 🔠 Partial Name Match | ✅      | Optional (contains, not exact match)        |
| 🌍 Google Maps Link   | ✅      | Automatically generated                     |
| 🌐 Localized Distance | ✅      | Based on selected display unit + language   |
| 📏 Unit Filter        | ✅      | `Kilometers`, `Meters`, `Miles`, `Nautical` |

---
