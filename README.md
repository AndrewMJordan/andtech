# Andtech

Standard utility assets for Unity

## Installation
1. Open the 'Package Manager' window in Unity.
2. Click on the + button in the top left. Choose "Add package from git URL..."
3. Type in https://github.com/AndrewMJordan/andtech.git#upm. Then press enter.

## Usage
Andtech code can accessed via the `Andtech` namespace.
```csharp
using Andtech;
using UnityEngine;

public class ExampleMonoBehaviour : MonoBehaviour {

    void Start() {
        Debug.Log("Welcome to Andtech!".Color(Color.yellow, Color.cyan));
    }
}

```
