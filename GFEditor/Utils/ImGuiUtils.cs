namespace GFEditor.Utils
{
    /// <summary>
    /// Contains many functions helper for ImGui !
    /// </summary>
    public static class ImGuiUtils
    {
        /// <summary>
        /// Draws a text label in the ImGui interface.
        /// </summary>
        /// <param name="labelName">The text to display as the label.</param>
        /// <param name="isSameLine">If true, the next UI element will be placed on the same line.</param>
        public static void Label(string labelName, bool isSameLine = true)
        {
            ImGui.Text(labelName);
            if (isSameLine) ImGui.SameLine();
        }

        /// <summary>
        /// Creates a list box with a selectable list of items.
        /// </summary>
        /// <param name="label">The label for the list box, displayed on the left.</param>
        /// <param name="selected_index">A reference to the currently selected index in the list.</param>
        /// <param name="values">The array of strings representing the selectable items.</param>
        public static bool ListBox(string label, ref int selected_index, string[] values)
        {
            if (!label.Contains("##")) Label(label);
            ImGui.SetNextWindowSize(new Vector2(100, 700), ImGuiCond.FirstUseEver);
            return ImGui.ListBox("##" + label, ref selected_index, values, values.Length);
        }

        /// <summary>
        /// Creates two buttons side by side, returning whether either of them was pressed.
        /// </summary>
        /// <param name="label1">The text for the first button.</param>
        /// <param name="label2">The text for the second button.</param>
        /// <param name="result1">Outputs true if the first button is pressed, otherwise false.</param>
        /// <param name="result2">Outputs true if the second button is pressed, otherwise false.</param>
        /// <param name="isSameLine">If true, both buttons will be placed on the same line.</param>
        /// <returns>True if either button is pressed, otherwise false.</returns>
        public static bool DoubleButton(string label1, string label2, out bool result1, out bool result2, bool isSameLine = true)
        {
            result1 = ImGui.Button(label1);
            if (isSameLine) ImGui.SameLine();
            result2 = ImGui.Button(label2);
            return result1 || result2;
        }

        /// <summary>
        /// Creates a draggable input field for modifying a long (64-bit signed integer) value.
        /// </summary>
        /// <param name="label">The label displayed next to the input field.</param>
        /// <param name="value">A reference to the long integer being modified.</param>
        public static void DragLong(string label, ref long value)
        {
            Label(label);
            unsafe
            {
                fixed (long* v = &value)
                {
                    ImGui.DragScalar("##" + label, ImGuiDataType.S64, v);
                }
            }
        }

        /// <summary>
        /// Creates a draggable input field for modifying an unsigned long (64-bit unsigned integer) value.
        /// </summary>
        /// <param name="label">The label displayed before the input field.</param>
        /// <param name="value">A reference to the unsigned long integer being modified.</param>
        public static void DragULong(string label, ref ulong value)
        {
            Label(label);
            unsafe
            {
                fixed (ulong* v = &value)
                {
                    ImGui.DragScalar("##" + label, ImGuiDataType.U64, v);
                }
            }
        }

        public static void InputChar(string label, ref char value)
        {
            Label(label);
            unsafe
            {
                fixed (char* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.S8, v);
                }
            }
        }

        public static void InputByte(string label, ref byte value)
        {
            Label(label);
            unsafe
            {
                fixed (byte* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.U8, v);
                }
            }
        }

        public static void InputShort(string label, ref short value)
        {
            Label(label);
            unsafe
            {
                fixed (short* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.S16, v);
                }
            }
        }

        public static void InputUShort(string label, ref ushort value)
        {
            Label(label);
            unsafe
            {
                fixed (ushort* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.U16, v);
                }
            }
        }

        public static void InputInt(string label, ref int value)
        {
            Label(label);
            ImGui.InputInt("##" + label, ref value);
        }

        public static void InputUInt(string label, ref uint value)
        {
            Label(label);
            unsafe
            {
                fixed (uint* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.U32, v);
                }
            }
        }

        /// <summary>
        /// Creates an input field for manually entering a long (64-bit signed integer) value.
        /// </summary>
        /// <param name="label">The label displayed before the input field.</param>
        /// <param name="value">A reference to the long integer being modified.</param>
        public static void InputLong(string label, ref long value)
        {
            Label(label);
            unsafe
            {
                fixed (long* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.S64, v);
                }
            }
        }

        /// <summary>
        /// Creates an input field for manually entering a long (64-bit signed integer) value with a step increment.
        /// </summary>
        /// <param name="label">The label displayed before the input field.</param>
        /// <param name="value">A reference to the long integer being modified.</param>
        /// <param name="step">The step increment applied when modifying the value.</param>
        public static void InputLong(string label, ref long value, ref long step)
        {
            Label(label);
            unsafe
            {
                fixed (long* v = &value)
                fixed (long* s = &step)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.S64, v, s);
                }
            }
        }

        /// <summary>
        /// Creates an input field for manually entering an unsigned long (64-bit unsigned integer) value.
        /// </summary>
        /// <param name="label">The label displayed before the input field.</param>
        /// <param name="value">A reference to the unsigned long integer being modified.</param>
        public static void InputULong(string label, ref ulong value)
        {
            Label(label);
            unsafe
            {
                fixed (ulong* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.U64, v);
                }
            }
        }

        /// <summary>
        /// Creates an input field for manually entering an unsigned long (64-bit unsigned integer) value with a step increment.
        /// </summary>
        /// <param name="label">The label displayed before the input field.</param>
        /// <param name="value">A reference to the unsigned long integer being modified.</param>
        /// <param name="step">The step increment applied when modifying the value.</param>
        public static void InputULong(string label, ref ulong value, ref ulong step)
        {
            Label(label);
            unsafe
            {
                fixed (ulong* v = &value)
                fixed (ulong* st = &step)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.U64, v, st);
                }
            }
        }

        public static void InputFloat(string label, ref float value)
        {
            Label(label);
            unsafe
            {
                fixed (float* v = &value)
                {
                    ImGui.InputScalar("##" + label, ImGuiDataType.Float, v);
                }
            }
        }

        public static bool InputText(string label, ref string result)
        {
            Label(label);
            return ImGui.InputText("##" + label, ref result, 256);
        }

        public static void Image(Texture2D texture, bool isSameLine = true)
        {
            ImGui.Image(texture.ToImGui(), new Vector2(texture.Width, texture.Height));
            if (isSameLine) ImGui.SameLine();
        }

        public static void ImageSized(Texture2D texture, Vector2 custSize)
        {
            ImGui.Image(texture.ToImGui(), custSize);
        }

        public static void SetOffsetPos(Vector2 offset)
        {
            var pos = ImGui.GetCursorPos();
            ImGui.SetCursorPos(new Vector2(pos.X + offset.X, pos.Y + offset.Y));
        }

        public static void SetCursorPos(Vector2 position, Vector2 offset)
        {
            ImGui.SetCursorPos(new Vector2(position.X + offset.X, position.Y + offset.Y));
        }

        public static void EnumBox<T>(string label, ref int selectedIndex, out T valueSelected, params T[] ignoredEnums)
        {
            var allNames = Enum.GetNames(typeof(T));
            var allValues = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            var filtered = allValues.Where(v => !ignoredEnums.Contains(v)).ToArray();
            var enumLists = filtered.Select(e => e?.ToString() ?? string.Empty).ToArray();
            Label(label);
            ImGui.ListBox("##" + label, ref selectedIndex, enumLists, enumLists.Length);
            valueSelected = filtered.Length > selectedIndex ? filtered[selectedIndex] : default;
        }

        public static bool CollapsingHeaderWithTexture(Texture2D texture, string label, bool isSameLine = true)
        {
            Image(texture, isSameLine);
            return ImGui.CollapsingHeader(label);
        }

        public static void ShowTooltip(string text)
        {
            if (ImGui.IsItemHovered())
                ImGui.SetTooltip(text);
        }
    }
}
