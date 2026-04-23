# Chemistry for All: Technical Manual

## Overview
This document describes the major systems and related classes used in this project.
It also contains other technical information needed for development.

## Table of Contents
1. [Screen Reader System](#screen-reader-system)
   1. [Overview](#overview-1)
   2. [Classes](#classes)
      - [Readable](#readable)
      - [ReadableComponent](#readablecomponent)
      - [ReadableDropdown](#readabledropdown)
      - [ReadableSlider](#readableslider)
      - [ReadableText](#readabletext)
      - [ReadableValue](#readablevalue)
2. [Lab Systems](#lab-systems)
   1. [Overview](#overview-2)
   2. [Classes](#classes-1)
3. [Building and Deployment](#building-and-deployment)


## Screen Reader System
### Overview

### Classes
#### Readable
*Inherits from: [MonoBehavior](https://docs.unity3d.com/6000.3/Documentation/ScriptReference/MonoBehaviour.html)*

Base class for all screen reader classes. It provides 2 fields to child classes: label and context. These fields
determine what should be read by TTS when the components needs to be read. Label is the literal text component that
labels the UI and context is a string that gives any other necessary context to the user. This context may contain 
variables related to the class and classes it inherits from. The base Readable includes the variable "{label}" which
is replaced by the text contained in the Label field when GetFullLabel is called. 

Classes inheriting from Readable are responsible for determining when the UI element should be read by TTS and can call
SpeakUI(string) with GetFullLabel() as the label parameter to do so. 

If extra variables are required for the child class, GetFullLabel should be overridden and the base
version of GetFullLabel should be called to acquire a label with base variables filled in. From there the child
implementation can replace their own variables.

**Example:**
``` C#
protected override string GetFullLabel()
{
    // Returns context with {label} replaced with the text from label and {variable} replaced with the value of var 
    return base.GetFullLabel().Replace("{variable}", var);
}
```

##### Fields 
| Field  | Description |
| ------------- | ------------- |
| public [TMP_Text](https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.2/api/TMPro.TMP_Text.html) label  | Label text for the UI element. |
| public string context  | Custom text to be read out alongside label, if unset label will be read instead. "{label}" will be replaced with the text in label. |

##### Methods
| Method | Description |
| ------------- | ------------- |
| protected void SpeakUI(string label) | Reads out the string label using the TTS system. |
| protected virtual string GetFullLabel()| Returns a string containing the full label based on the label and context fields. If context is empty then it returns label, else it returns context with any instances of "{label}" replaced with the text from the label field. |


#### ReadableComponent
*Inherits from: [Readable](#readable), [ISelectHandler](https://docs.unity3d.com/Packages/com.unity.ugui@2.5/api/UnityEngine.EventSystems.ISelectHandler.html)*

Child class of Readable that calls SpeakUI when it is selected (see [ISelectHandler](https://docs.unity3d.com/Packages/com.unity.ugui@2.5/api/UnityEngine.EventSystems.ISelectHandler.html)). This component can be placed on any UI element, which will make the element
be read by the TTS when it is selected. Classes for specific UI elements that need to implement extra context variables or 
other functionality should inherit from this class.

##### Methods
| Method | Description |
| ------------- | ------------- |
| public void OnSelect(BaseEventData eventData) | Implementation from [ISelectHandler](https://docs.unity3d.com/Packages/com.unity.ugui@2.5/api/UnityEngine.EventSystems.ISelectHandler.html). Calls SpeakUI with GetFullLabel when this UI element is selected. |


#### ReadableDropdown
*Inherits from: [ReadableComponent](#readablecomponent), [ISubmitHandler](https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.ISubmitHandler.html)*

Child of ReadableComponent with dropdown specific functions. Reads out "expanded" when expanded. Adds the context variables "{items}" which is the amount 
of items in the dropdown and "{selected}" which is the currently selected item. 

##### Fields 
| Field  | Description |
| ------------- | ------------- |
| public [TMP_Dropdown](https://docs.unity3d.com/Packages/com.unity.textmeshpro@1.2/api/TMPro.TMP_Dropdown.html) dropdown  | Used for getting information about the dropdown. |

##### Methods
| Method | Description |
| ------------- | ------------- |
| public void OnSubmit(BaseEventData eventData) | Implementation from [ISubmitHandler](https://docs.unity3d.com/2019.1/Documentation/ScriptReference/EventSystems.ISubmitHandler.html). Reads out "expanded" when the dropdown is expanded. |
| protected override string GetFullLabel() | Returns context filled in with variables from [Readable](#readable) and fills in "{items}" with the number of items in the dropdown and "{selected}" with the currently selected item in the dropdown |


### ReadableSlider
*Inherits from: [ReadableComponent](#readablecomponent)*

Readable slider component. Reads out context when selected and reads value when changed. Adds the context variable "{value}",
which is the current value of the slider.

##### Fields 
| Field  | Description |
| ------------- | ------------- |
| public Slider slider | Used for getting information about the slider. |
| private float currentValue | Stores current value for GetFullLabel() |

##### Methods
| Method | Description |
| ------------- | ------------- |
| private void OnValueChanged(float value) | Reads value when changed and updates currentValue |
| protected override string GetFullLabel() | Returns context filled in with variables from [Readable](#readable) and fills in "{value}" with the current value of the slider |

#### ReadableText
*Inherits from: [Readable](#readable)*
Exposes a function (ReadText) to read out the label. This allows a button's UnityEvent to 
call the function which can be set up within the editor (see [Unity Docs](https://docs.unity3d.com/6000.3/Documentation/Manual/unity-events.html)).

##### Methods
| Method | Description |
| ------------- | ------------- |
| public void ReadText() | Reads out the full label using SpeakUI. |

#### ReadableValue
*Inherits from: [Readable](#readable)*

Reads out the value of a text component when its text value is changed.

*Note: ReadableText with a button is preferred over ReadableValue to avoid TTS being accidentally interrupted. The former solution also allows the user
to read text at anytime rather than only when it changes, which is preferred.*

##### Fields 
| Field  | Description |
| ------------- | ------------- |
| private string currentText | Keeps track of the current text in label. |

##### Methods
| Method | Description |
| ------------- | ------------- |
| private void OnTextChange() | Called when label text is changed and reads out the new label. |


## Lab Systems
### Overview

### Classes 

## Building and Deployment

