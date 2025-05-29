using NLog;
using System.Diagnostics;

namespace GFEditor.Widgets.Notify
{
    public enum ImGuiToastType : byte
    {
        None,
        Success,
        Warning,
        Error,
        Info,
        Max
    }

    public enum ImGuiToastPhase : byte
    {
        FadeIn,
        Wait,
        FadeOut,
        Expired,
        Max
    }

    public enum ImGuiToastPos : byte
    {
        TopLeft,
        TopCenter,
        TopRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
        Center,
        Max
    }

    public class ImGuiToast
    {
        private const int NOTIFY_FADE_IN_OUT_TIME = 150; // Fade in and out duration
        private const int NOTIFY_DEFAULT_DISMISS = 3000; // Auto dismiss after X ms
        private const float NOTIFY_OPACITY = 0.8f; // 0-1 Toast opacity
        private const ImGuiWindowFlags NOTIFY_DEFAULT_TOAST_FLAGS = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoNav | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoFocusOnAppearing;
        private Action? OnButtonPress; // A lambda variable, which will be executed when button in notification is pressed
        private ImGuiWindowFlags Flags = NOTIFY_DEFAULT_TOAST_FLAGS;
        private ImGuiToastType Type = ImGuiToastType.None;
        private readonly int DismissTime = NOTIFY_DEFAULT_DISMISS;
        private readonly Stopwatch Watch = Stopwatch.StartNew();
        private string? Title;
        private string? Content;
        private string? ButtonLabel;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool NOTIFY_NULL_OR_EMPTY(string? str) => string.IsNullOrEmpty(str);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string NOTIFY_FORMAT(string format, params object?[] args)
        {
            if (args.Length <= 0) return format;
            return string.Format(format, args);
        }

        public ImGuiToast(ImGuiToastType type, string title, int dismissTime = NOTIFY_DEFAULT_DISMISS)
        {
            if (type >= ImGuiToastType.Max) throw new ArgumentOutOfRangeException(nameof(type));
            Type = type;
            DismissTime = dismissTime;
            Title = string.Empty;
            Content = string.Empty;
            SetTitle(title);
        }

        public ImGuiToast(ImGuiToastType type, string title, string contentFormat, params object?[] args)
        {
            if (type >= ImGuiToastType.Max) throw new ArgumentOutOfRangeException(nameof(type));
            Type = type;
            SetTitle(title);
            SetContent(contentFormat, args);
        }

        public ImGuiToast(ImGuiToastType type, string title, int dismissTime, string contentFormat, params object?[] args)
        {
            if (type >= ImGuiToastType.Max) throw new ArgumentOutOfRangeException(nameof(type));
            Type = type;
            DismissTime = dismissTime;
            SetTitle(title);
            SetContent(contentFormat, args);
        }

        public ImGuiToast(ImGuiToastType type, string title, int dismissTime, Action? onButtonPressed, string buttonLabel, string contentFormat, params object?[] args)
        {
            if (type >= ImGuiToastType.Max) throw new ArgumentOutOfRangeException(nameof(type));
            Type = type;
            DismissTime = dismissTime;
            OnButtonPress = onButtonPressed;
            SetTitle(title);
            SetContent(contentFormat, args);
            SetButtonLabel(buttonLabel);
        }

        public void SetTitle(string format, params object?[] args)
        {
            Title = NOTIFY_FORMAT(format, args);
        }

        private void SetContent(string format, params object?[] args)
        {
            Content = NOTIFY_FORMAT(format, args);
        }

        private void SetButtonLabel(string format, params object?[] args)
        {
            ButtonLabel = NOTIFY_FORMAT(format, args);
        }

        public void SetType(ImGuiToastType type)
        {
            if (type >= ImGuiToastType.Max)
                throw new ArgumentOutOfRangeException(nameof(type));
            Type = type;
        }

        public void SetWindowFlags(ImGuiWindowFlags flags)
        {
            Flags = flags;
        }

        public void SetOnButtonPress(Action onButtonPress)
        {
            OnButtonPress = onButtonPress;
        }

        public string? GetTitle()
        {
            return Title;
        }

        public string? GetDefaultTitle()
        {
            if (NOTIFY_NULL_OR_EMPTY(Title))
            {
                return GetToastType() switch
                {
                    ImGuiToastType.Success => "Success",
                    ImGuiToastType.Info => "Info",
                    ImGuiToastType.Error => "Error",
                    ImGuiToastType.Warning => "Warning",
                    _ => string.Empty,
                };
            }

            return Title;
        }

        public ImGuiToastType GetToastType()
        {
            return Type;
        }

        public Vector4 GetColor()
        {
            return GetToastType() switch
            {
                ImGuiToastType.Success => new Vector4(0f, 1f, 0f, 1f),
                ImGuiToastType.Error => new Vector4(1f, 0f, 0, 1f),
                ImGuiToastType.Warning => new Vector4(1f, 1f, 0, 1f),
                ImGuiToastType.Info => new Vector4(1f, 0.75f, 1f, 1f),
                _ => new Vector4(1f, 1f, 1f, 1f),
            };
        }

        public string GetIcon()
        {
            return Type switch
            {
                ImGuiToastType.None => string.Empty,
                ImGuiToastType.Success => FontAwesome6.CircleCheck,
                ImGuiToastType.Warning => FontAwesome6.TriangleExclamation,
                ImGuiToastType.Error => FontAwesome6.CircleExclamation,
                ImGuiToastType.Info => FontAwesome6.CircleInfo,
                _ => string.Empty
            };
        }

        public string? GetContent()
        {
            return Content;
        }

        public long GetElapsedTime()
        {
            return Watch.ElapsedMilliseconds;
        }

        public ImGuiToastPhase GetPhase()
        {
            var elapsed = GetElapsedTime();
            if (elapsed > NOTIFY_FADE_IN_OUT_TIME + DismissTime + NOTIFY_FADE_IN_OUT_TIME)
                return ImGuiToastPhase.Expired;
            else if (elapsed > NOTIFY_FADE_IN_OUT_TIME + DismissTime)
                return ImGuiToastPhase.FadeOut;
            else if (elapsed > NOTIFY_FADE_IN_OUT_TIME)
                return ImGuiToastPhase.Wait;
            else
                return ImGuiToastPhase.FadeIn;
        }

        public float GetFadePercent()
        {
            var phase = GetPhase();
            var elapsed = GetElapsedTime();
            if (phase == ImGuiToastPhase.FadeIn)
                return elapsed / (float)NOTIFY_FADE_IN_OUT_TIME * NOTIFY_OPACITY;
            else if (phase == ImGuiToastPhase.FadeOut)
                return (1.0f - (elapsed - (float)NOTIFY_FADE_IN_OUT_TIME - DismissTime) / NOTIFY_FADE_IN_OUT_TIME) * NOTIFY_OPACITY;
            return 1.0f * NOTIFY_OPACITY;
        }

        public ImGuiWindowFlags GetWindowFlags()
        {
            return Flags;
        }

        public Action? GetOnButtonPress()
        {
            return OnButtonPress;
        }

        public string? GetButtonLabel()
        {
            return ButtonLabel;
        }
    }

    /// <summary>
    /// Ported Notify from: https://github.com/TyomaVader/ImGuiNotify/tree/Dev
    /// </summary>
    public static class ImGuiNotify
    {
        private const float NOTIFY_PADDING_X = 20f; // Bottom-left X padding
        private const float NOTIFY_PADDING_Y = 20f; // Bottom-left Y padding
        private const float NOTIFY_PADDING_MESSAGE_Y = 10f; // Padding Y between each message
        private const ImGuiWindowFlags NOTIFY_DEFAULT_TOAST_FLAGS = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoNav | ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoFocusOnAppearing;
        private static readonly List<ImGuiToast> Notifications = [];
        private static int NOTIFY_RENDER_LIMIT = 8; // Max number of toasts rendered at the same time
        private static bool NOTIFY_USE_SEPARATOR = true; // If true, a separator will be rendered between the title and the content
        private static bool NOTIFY_USE_DISMISS_BUTTON = true; // If true, a dismiss button will be rendered in the top right corner of the toast
        private static bool NOTIFY_RENDER_OUTSIDE_MAIN_WINDOW = false; // If true, the notifications will be rendered in the corner of the monitor, otherwise in the corner of the main window

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool NOTIFY_NULL_OR_EMPTY(string? str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// If true, a separator will be rendered between the title and the content (Default: true)
        /// </summary>
        public static void EnableSeparator(bool enabled) => NOTIFY_USE_SEPARATOR = enabled;
        /// <summary>
        /// If true, a dismiss button will be rendered in the top right corner of the toast (Default: true)
        /// </summary>
        public static void EnableDismissButton(bool enabled) => NOTIFY_USE_DISMISS_BUTTON = enabled;
        /// <summary>
        /// Max number of toasts rendered at the same time (Default: 8)
        /// </summary>
        public static void SetRenderLimit(int maxNotify = 8) => NOTIFY_RENDER_LIMIT = maxNotify;
        /// <summary>
        /// If true, the notifications will be rendered in the corner of the monitor, otherwise in the corner of the main window (Default: false)
        /// </summary>
        public static void EnableRenderOutsideMainWindow(bool enabled) => NOTIFY_RENDER_OUTSIDE_MAIN_WINDOW = enabled;

        /// <summary>
        /// Setup the FontAwesome6 icons required for the Notify event.
        /// </summary>
        public static void Setup()
        {
            var io = ImGui.GetIO();
            uint[] iconsRanges = [FontAwesome6.IconMin, FontAwesome6.IconMax];
            float baseFontSize = 16.0f;
            float iconFontSize = baseFontSize * 2.0f / 3.0f; // FontAwesome fonts need to have their sizes reduced by 2.0f/3.0f in order to align correctly

            ImFontConfig iconsConfig;
            iconsConfig.MergeMode = 1;
            iconsConfig.PixelSnapH = 1;
            iconsConfig.FontDataOwnedByAtlas = 1;
            iconsConfig.GlyphMinAdvanceX = iconFontSize;
            iconsConfig.GlyphMaxAdvanceX = float.MaxValue;
            iconsConfig.RasterizerMultiply = 1f;
            iconsConfig.RasterizerDensity = 1f;

            unsafe {
                fixed(uint* compDataPtr = FASolid900.CompressedData)
                fixed(uint* iconRangePtr = iconsRanges)
                {
                    io.Fonts.AddFontFromMemoryCompressedTTF(compDataPtr, FASolid900.CompressedSize, iconFontSize, &iconsConfig, iconRangePtr);
                }
            }
        }

        public static void Insert(ImGuiToast toast)
        {
            Notifications.Add(toast);
        }

        public static void Remove(int index)
        {
            Notifications.RemoveAt(index);
        }

        public static void RenderNotifications(bool defaultStyle = true)
        {
            var mainWindowSize = ImGui.GetMainViewport().Size;
            var height = 0f;

            for (int i = 0; i < Notifications.Count; i++)
            {
                var toast = Notifications[i];
                if (toast == null)
                {
                    Remove(i);
                    continue;
                }

                if (toast.GetPhase() == ImGuiToastPhase.Expired)
                {
                    Remove(i);
                    continue;
                }

                if (i > NOTIFY_RENDER_LIMIT)
                    continue;

                var icon = toast.GetIcon();
                var title = toast.GetTitle();
                var content = toast.GetContent();
                var defaultTitle = toast.GetDefaultTitle();
                var opacity = toast.GetFadePercent();
                var color = toast.GetColor();
                var buttonCallback = toast.GetOnButtonPress();
                var wasTitleRendered = false;

                ImGui.SetNextWindowBgAlpha(opacity);

                if (NOTIFY_RENDER_OUTSIDE_MAIN_WINDOW)
                {
                    unsafe
                    {
                        var mainMonitor = ((ImGuiViewportP*)ImGui.GetMainViewport().Handle)->PlatformMonitor;
                        var monitor = ImGui.GetPlatformIO().Monitors[mainMonitor];
                        ImGui.SetNextWindowPos(new Vector2(monitor.WorkPos.X + monitor.WorkSize.X - NOTIFY_PADDING_X, monitor.WorkPos.Y + monitor.WorkSize.Y - NOTIFY_PADDING_Y - height), ImGuiCond.Always, new Vector2(1.0f, 1.0f));
                    }
                }
                else
                {
                    var mainWindowPos = ImGui.GetMainViewport().Pos;
                    ImGui.SetNextWindowPos(new Vector2(mainWindowPos.X + mainWindowSize.X - NOTIFY_PADDING_X, mainWindowPos.Y + mainWindowSize.Y - NOTIFY_PADDING_Y - height), ImGuiCond.Always, new Vector2(1.0f, 1.0f));
                }

                if (!NOTIFY_USE_DISMISS_BUTTON && buttonCallback == null)
                    toast.SetWindowFlags(NOTIFY_DEFAULT_TOAST_FLAGS | ImGuiWindowFlags.NoInputs);

                unsafe
                {
                    if (ImGui.Begin($"##TOAST{i}", null, toast.GetWindowFlags()))
                    {
                        ImGuiP.BringWindowToDisplayFront(ImGuiP.GetCurrentWindow());
                        ImGui.PushTextWrapPos(mainWindowSize.X / 3f); // We want to support multi-line text, this will wrap the text after 1/3 of the screen width

                        if (!NOTIFY_NULL_OR_EMPTY(icon))
                        {
                            ImGui.TextColored(color, icon);
                            wasTitleRendered = true;
                        }

                        if (!NOTIFY_NULL_OR_EMPTY(title))
                        {
                            if (!NOTIFY_NULL_OR_EMPTY(icon))
                                ImGui.SameLine();

                            ImGui.Text(title);
                            wasTitleRendered = true;
                        }
                        else if (!NOTIFY_NULL_OR_EMPTY(defaultTitle))
                        {
                            if (!NOTIFY_NULL_OR_EMPTY(icon))
                                ImGui.SameLine();

                            ImGui.Text(defaultTitle); // Render default title text (ImGuiToastType_Success -> "Success", etc...)
                            wasTitleRendered = true;
                        }

                        if (NOTIFY_USE_DISMISS_BUTTON)
                        {
                            if (wasTitleRendered || !NOTIFY_NULL_OR_EMPTY(content))
                                ImGui.SameLine();

                            float scale = 0.9f;
                            if (ImGui.CalcTextSize(content).X > ImGui.GetContentRegionAvail().X)
                                scale = 0.8f;

                            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + (ImGui.GetWindowSize().X - ImGui.GetCursorPosX()) * scale);
                            if (ImGui.Button(FontAwesome6.Xmark))
                                Remove(i);
                        }

                        // In case ANYTHING was rendered in the top, we want to add a small padding so the text (or icon) looks centered vertically
                        if (wasTitleRendered && !NOTIFY_NULL_OR_EMPTY(content))
                        {
                            ImGui.SetCursorPosY(ImGui.GetCursorPosY() + 5f);
                        }

                        // If a content is set
                        if (!NOTIFY_NULL_OR_EMPTY(content))
                        {
                            if (wasTitleRendered && NOTIFY_USE_SEPARATOR)
                                ImGui.Separator();
                            ImGui.Text(content);
                        }

                        if (buttonCallback != null)
                        {
                            if (ImGui.Button(toast.GetButtonLabel()))
                                buttonCallback.Invoke();
                        }

                        ImGui.PopTextWrapPos();
                        height += ImGui.GetWindowHeight() + NOTIFY_PADDING_MESSAGE_Y;
                    }
                    ImGui.End();
                }
            }
        }
    }
}
