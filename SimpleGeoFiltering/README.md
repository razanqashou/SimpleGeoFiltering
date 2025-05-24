Perfect! Here's your **complete documentation** for the `SimpleGeoFiltering` package, now **including everything** in one clean and organized explanation:

---

# 🌍 `SimpleGeoFiltering` – Full Documentation with Flow, Endpoint & JSON Examples

---

## 📦 Package Purpose

The `SimpleGeoFiltering` package helps you **filter and return a list of nearby places** based on:

* ✅ User’s current location (latitude & longitude)
* 🗺️ Optional filters like **country**, **region**, and **tags**
* 📏 Radius: in kilometers, meters, miles, or nautical miles

---

## 🛠️ One-Time Setup

### 1. Install the Package via NuGet

```bash
Install-Package SimpleGeoFiltering
```

---

### 2. Configure the Service in `Program.cs`

```csharp
builder.Services.AddSimpleGeoFiltering();
```

Now you can inject and use `_geoFilterService` anywhere via DI.

---

## ⚙️ Usage Flow with Practical Example

Let’s say your user is standing in **Amman, Jordan**, and you want to find tourist places nearby.

---

### 🔹 Step 1: Prepare the User Location

```csharp
var userLocation = new GeoPoint
{
    Latitude = 31.9539,
    Longitude = 35.9106
};
```

---

### 🔹 Step 2: Prepare the List of Places

Each place should include:

* Name
* Latitude / Longitude
* Country, Region
* Tags (e.g. "tourism", "history")

---

### 🔹 Step 3: Call the Filtering Method

```csharp
var results = _geoFilterService.FindWithinRadius(
    center: userLocation,
    points: yourListOfPlaces,
    radius: 10,
    radiusUnit: DistanceUnit.Kilometers,
    country: "Jordan",
    region: "Amman",
    tags: new List<string> { "tourism" }
);
```

---

### 🔹 Step 4: Get the Filtered Results

You will get only places:

* 📍 Within 10 km radius
* 🏙️ Located in Jordan, Amman
* 🏷️ Tagged with "tourism"

Each result includes:

* Name
* Coordinates
* Google Map URL
* Formatted distance (like `2.30 km` or `1.94 miles`)

---

## ✅ Package Features

| Feature                | Description                                        |
| ---------------------- | -------------------------------------------------- |
| 🧠 Smart Filtering     | Based on distance, location, tags, etc.            |
| 🌍 Multilingual        | Supports Arabic and English labels                 |
| 🧩 Dependency Injected | Easy to plug into any .NET project                 |
| 📐 Accurate Logic      | Uses geospatial math to calculate real distances   |
| ✨ Clean Results        | Includes formatted map URLs and readable distances |

---

## 🧪 API Endpoint Example

```csharp
[HttpPost("search")]
public IActionResult SearchWithinRadius([FromBody] GeoSearchRequest request)
{
    var result = _geoFilterService.FindWithinRadius(
        request.Center,
        request.Points,
        request.Radius,
        request.RadiusUnit,
        request.Country,
        request.Region,
        request.Tags
    );

    return Ok(result);
}
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

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public DistanceUnit DisplayUnit { get; set; }
}
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
      "tags": ["nature", "tourism"]
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

