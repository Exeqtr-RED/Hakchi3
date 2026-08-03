// This file exists only so that the ce-data project (which has no .cs source otherwise)
// produces a DLL on build. The project's real job is its PreBuild target, which uses
// tools/busybox on Windows to assemble GeneratedData/ tarballs that hakchi_gui later
// embeds as resources. See ce-data.csproj for the PreBuild target.
namespace ce_data;

internal static class _BuildTrigger
{
    // No-op. The single field below prevents the compiler from warning about an empty type.
    internal const string Purpose = "Build order trigger for ce-data.csproj; see PreBuild target.";
}
