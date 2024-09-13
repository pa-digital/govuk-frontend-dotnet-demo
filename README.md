# GOV.UK Design System .Net Implementation User Guide

The GOV.UK Design System is an official design framework produced by the UK Government and defines best practices and rules that must be followed to ensure that your code base is GDS Compliant.

You can find the guide at the <a href="https://design-system.service.gov.uk/" target="_blank" rel="noreferrer">GOV.UK Design System</a> website.

## NuGet Package use in your target project

If you just with to use the package as is direct from the repository then simply install the latest version of the NuGet Package GDS.Components using your favourite package manager.

After installing the package you will need to reference the package in your program.cs file

Add usings to allow references
```bash
using Microsoft.Extensions.FileProviders;
using GDS.Components;
```

Extend the services to allow the compiler to pull in all required references
```bash
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation(options =>
    {
        options.FileProviders.Add(new EmbeddedFileProvider(typeof(ResourceMarker).Assembly));
    })
    .AddMvcOptions(options =>
    {
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "The field is required.");
    });
```

## Pre-Requisites

In your project file you will need to add the following elements to ensure that all the client side files are imported

```bash
	<ItemGroup>
		<GdsCssContent Include="$(NuGetPackageRoot)gds.components/*/contentFiles/any/any/wwwroot/lib/gds/dist/css/govuk.css" />
		<GdsJsContent Include="$(NuGetPackageRoot)gds.components/*/contentFiles/any/any/wwwroot/lib/gds/dist/js/gds.js" />
		<GdsFontContent Include="$(NuGetPackageRoot)gds.components/*/contentFiles/any/any/wwwroot/lib/gds/dist/css/assets/fonts/bold-affa96571d-v2.woff" />
		<GdsFontContent Include="$(NuGetPackageRoot)gds.components/*/contentFiles/any/any/wwwroot/lib/gds/dist/css/assets/fonts/light-f591b13f7d-v2.woff" />
		<GdsFontContent Include="$(NuGetPackageRoot)gds.components/*/contentFiles/any/any/wwwroot/lib/gds/dist/css/assets/fonts/light-94a07e06a1-v2.woff2" />
		<GdsFontContent Include="$(NuGetPackageRoot)gds.components/*/contentFiles/any/any/wwwroot/lib/gds/dist/css/assets/fonts/bold-b542beb274-v2.woff2" />
	</ItemGroup>
```

You will also need to add a target reference to regenerate files on build

```
	<Target Name="CopyGdsContentFiles" AfterTargets="Build">
		<MakeDir Directories="$(ProjectDir)wwwroot/lib/gds/dist/css" />
		<MakeDir Directories="$(ProjectDir)wwwroot/lib/gds/dist/js" />
		<MakeDir Directories="$(ProjectDir)wwwroot/lib/gds/dist/css/assets/fonts" />
		<Copy SourceFiles="@(GdsCssContent)" DestinationFolder="$(ProjectDir)wwwroot/lib/gds/dist/css" SkipUnchangedFiles="true" />
		<Copy SourceFiles="@(GdsJsContent)" DestinationFolder="$(ProjectDir)wwwroot/lib/gds/dist/js" SkipUnchangedFiles="true" />
		<Copy SourceFiles="@(GdsFontContent)" DestinationFolder="$(ProjectDir)wwwroot/lib/gds/dist/css/assets/fonts" SkipUnchangedFiles="true" />
	</Target>
```

When you complete your first build, your content files will be published to the wwwroot folder

## Branding

This demo project has two scss files included that demonstrate how the library can be branded for different uses.
