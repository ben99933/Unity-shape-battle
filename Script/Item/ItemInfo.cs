using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    int rows;//行數 最大值為10

    string info_1 = "";
    string info_2 = "";
    string info_3 = "";
    string info_4 = "";
    string info_5 = "";
    string info_6 = "";
    string info_7 = "";
    string info_8 = "";
    string info_9 = "";
    string info_10 = "";

    public ItemInfo(int row)
    {
        if (row > 10)
        {
            row = 10;
        }
        rows = row;
    }

    public void AddInfo(int rowNumber, string infomation)
    {
        int ro;
        if (rowNumber > rows)
        {
            ro = rows;
        }
        else
        {
            ro = rowNumber;
        }
        switch (ro)
        {
            case 1:
                info_1 = infomation;
                break;
            case 2:
                info_2 = infomation;
                break;
            case 3:
                info_3 = infomation;
                break;
            case 4:
                info_4 = infomation;
                break;
            case 5:
                info_5 = infomation;
                break;
            case 6:
                info_6 = infomation;
                break;
            case 7:
                info_7 = infomation;
                break;
            case 8:
                info_8 = infomation;
                break;
            case 9:
                info_9 = infomation;
                break;
            case 10:
                info_10 = infomation;
                break;
        }
    }

    public string GetInfo(int rowNumber)
    {
        int ro;
        if (rowNumber > rows)
        {
            ro = rows;
        }
        else {
            ro = rowNumber;
        }
        switch (ro)
        {
            case 1:
                return info_1;
            case 2:
                return info_2;
            case 3:
                return info_3;
            case 4:
                return info_4;
            case 5:
                return info_5;
            case 6:
                return info_6;
            case 7:
                return info_7;
            case 8:
                return info_8;
            case 9:
                return info_9;
            case 10:
                return info_10;
        }
        return "no found!!";
    }

}
