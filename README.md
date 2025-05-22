
# 🖼️ HTML Picture Path Updater

A simple C# console application that updates the image paths inside `<picture>` tags in an HTML file.  
Perfect for batch-replacing image URLs when moving content between servers or renaming galleries.

---

## ✨ Features

- ✅ Replace a specific number of `<picture>` tags
- ✅ Replace only image paths starting with a specific base path
- ✅ Automatically renames images using a number format (e.g. `01.jpg`, `02.jpg`, ...)
- ✅ Saves the modified HTML file as `updated.html` in the same folder

---

## 🛠️ Usage

1. Clone or download the project
2. Build the project in Visual Studio (requires [.NET](https://dotnet.microsoft.com/en-us/download))
3. Run the compiled `.exe` or run from terminal/console

---

### 🧪 Sample Input

You have this in your HTML:

```html
<picture>
  <source srcset="https://old-domain.com/images/gallery/photo1.jpg" />
  <img src="https://old-domain.com/images/gallery/photo1.jpg" />
</picture>
```

---

### 🚀 When running the app:

```
Enter the full path to your HTML file: C:\Users\user\Desktop\index.html
How many images to update? 3
Enter the old base path to replace: https://old-domain.com/images/gallery/
Enter the new base path: https://new-domain.com/images/event/
```

---

### ✅ Result (after update)

```html
<picture>
  <source srcset="https://new-domain.com/images/event/01.jpg" />
  <img src="https://new-domain.com/images/event/01.jpg" />
</picture>
```

---

## 📄 Output

The updated HTML will be saved as:

```
updated.html
```

in the **same folder** as the original.

---

## 📦 Dependencies

- [HtmlAgilityPack](https://www.nuget.org/packages/HtmlAgilityPack/)

Install via NuGet:

```bash
Install-Package HtmlAgilityPack
```
