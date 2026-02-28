public static class CommonSettingsData
{
    public struct SettingsKeys 
    {
        /// <summary> Quality and Rendering Settings </summary>
        public const string QualitySettingsKey = "Quality";
        public const string DisplaySettingsKey = "Display";
        public const string ResolutionSettingsKey = "Resolutions";
        public const string AnisotropicFilteringKey = "AnisotropicFiltering";
        public const string DLSSSettingsKey = "DLSS";
        public const string AntiAlizingKey = "AntiAlizing";

        /// <summary> FPS Settings </summary>
        public const string ShowFPSToggleKey = "show_fps_toggle";
        public const string HideFPSToggleKey = "hide_fps_toggle";

        public const string ShowFPSCounterKey = "show_fps_counter";
        public const string HideFPSCounterKey = "hide_fps_counter";

        /// <summary> Shadow Map Quality Settings </summary>
        public const string ShadowMapQualityKey = "shadow_map_quality";

        /// <summary> Ambient Occlusion Settings </summary>
        public const string ShowAmbientOcclusionToggleKey = "show_ambient_occlusion_toggle";
        public const string HideAmbientOcclusionToggleKey = "hide_ambient_occlusion_toggle";

        public const string AmbientOcclusionQualityVisibleKey = "ambient_occlusion_quality_visible";
        public const string AmbientOcclusionQualityKey = "ambient_occlusion_quality";

        /// <summary> Contact Shadows Settings </summary>
        public const string ContactShadowsKeys = "contact_shadows";

        /// <summary> Cascaded Shadow Maps Settings </summary>
        public const string ShowCascadedShadowMapsKey = "show_cascaded_shadow_maps";
        public const string HideCascadedShadowMapsKey = "hide_cascaded_shadow_maps";

        /// <summary> Fog Quality Settings </summary>
        public const string FogQualitySettingsKey = "fog_quality_settings";

        /// <summary> Lens Flare Settings </summary>
        public const string ShowLensFlareKey = "show_lens_flare";
        public const string HideLensFlareKey = "hide_lens_flare";

        /// <summary> Micro Shadows Settings </summary>
        public const string ShowMicroShadowsKey = "show_micro_shadows";
        public const string HideMicroShadowsKey = "hide_micro_shadows";
    }
}
