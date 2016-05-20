/****************************************************
** ���ߣ� Halower (QQ:121625933)
** ��ʼʱ�䣺2015-02-01
** ������jqGrid��չö��
*****************************************************/

using System;

namespace HalowerHub.JqGrid
{
    [Flags]
    public enum GridOperators
    {
        Add = 1,
        Edit = 2,
        Delete = 4,
        Search = 16,
        Refresh = 32
    }
}