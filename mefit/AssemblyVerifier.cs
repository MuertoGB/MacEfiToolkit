// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// AssemblyVerifier.cs
// Released under the GNU GLP v3.0

using Mac_EFI_Toolkit.WIN32;

public static class AssemblyVerifier
{
    internal static bool VerifyAssemblyStrongNameSignature(string assemblyPath)
    {
        try
        {
            bool wasVerified = false;
            bool result = NativeMethods.StrongNameSignatureVerificationEx(assemblyPath, false, ref wasVerified);
            return result && wasVerified;
        }
        catch
        {
            return false;
        }
    }
}