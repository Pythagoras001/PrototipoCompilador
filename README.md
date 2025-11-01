# 🧠 Prototipo de Compilador en C# con GOLD Parser y Windows Forms

Este proyecto implementa un **prototipo funcional de compilador** desarrollado en **C# (.NET Framework)** utilizando la herramienta **GOLD Parser Engine**.  
El sistema cuenta con una **interfaz gráfica en Windows Forms**, capaz de **analizar código fuente**, **verificar la validez del lenguaje**, y **detectar errores léxicos y sintácticos** en tiempo de ejecución.

---

## 🚀 Características principales

- ✅ **Análisis léxico y sintáctico automático** mediante archivos `.egt` generados por GOLD Parser Builder.  
- 🧩 **Interfaz gráfica intuitiva** construida en **Windows Forms**.  
- ⚙️ **Detección y reporte de errores léxicos y sintácticos** con mensajes detallados (línea, columna y tipo de error).  
- 📜 **Ventana de resultados** con el log de tokens, errores y aceptación de la cadena.  
- 🧠 **Estructura modular** que separa la lógica del compilador y la interfaz.  
- 💡 **Soporte para nuevos lenguajes**: basta con reemplazar el archivo `.egt` con una gramática diferente.

---

## ⚙️ Funcionamiento general

1. El usuario carga o escribe el código fuente en el editor.  
2. Al presionar **"Analizar"**, el programa:
   - Pasa el texto al **analizador léxico**, el cual convierte la entrada en tokens válidos.
   - Luego, el **analizador sintáctico (parser)** valida la estructura según la gramática definida.
3. Si la entrada es válida:
   - Se muestra el mensaje **“Análisis exitoso”**.
4. Si existen errores:
   - Se listan los **errores léxicos o sintácticos**, indicando **línea, columna y símbolo**.

---

## 🧩 Tecnologías utilizadas

| Tecnología | Descripción |
|-------------|--------------|
| **C#** | Lenguaje principal del proyecto. |
| **.NET Framework / Windows Forms** | Para la interfaz gráfica y manejo de eventos. |
| **GOLD Parser Engine (C#)** | Motor para ejecutar gramáticas compiladas en `.egt`. |
| **GOLD Parser Builder** | Herramienta para diseñar y generar la gramática del lenguaje. |

