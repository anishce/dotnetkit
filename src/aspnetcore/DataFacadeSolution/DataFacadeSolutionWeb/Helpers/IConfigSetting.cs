// ************************************************************************
// Copyright (c) AnishCeDev All Rights Reserved.
// Author: AnishCeDev
// ************************************************************************

namespace DataFacadeSolutionWeb.Helpers
{
    public interface IConfigSetting
    {
        string GetConnectionString(string name);
        T? GetValue<T>(string keys);
    }
}