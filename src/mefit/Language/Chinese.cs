// Mac EFI Toolkit
// https://github.com/MuertoGB/MacEfiToolkit

// Chinese.cs
// Released under the GNU GLP v3.0

namespace Mac_EFI_Toolkit
{
    internal class APPSTRINGS
    {
        #region Strings
        internal const string APPNAME =
            "Mac EFI Toolkit";

        internal const string VERSION =
            "版本";

        internal const string LZMA_SDK =
            "LZMA SDK";

        internal const string BACKUP =
            "备份";

        internal const string EFIROM =
            "EFIROM";

        internal const string SOCROM =
            "SOCROM";

        internal const string FILE =
            "文件";

        internal const string UNKNOWN =
            "未知";

        internal const string NA =
            "N/A";

        internal const string BYTES =
            "字节";

        internal const string SERIAL_NUMBER =
            "序列号";

        internal const string FW_PARSE_TIME =
            "固件解析时间";

        internal const string HIDE =
            "隐藏";

        internal const string SHOW =
            "显示";

        internal const string INVALID =
            "无效";

        internal const string CONTACT_SERVER =
            "正在联系服务器...";

        internal const string NOT_FOUND =
            "未找到";

        internal const string FIRMWARE_INFO =
            "固件信息";

        internal const string ROM_SECTION_INFO =
            "Apple ROM 信息";

        internal const string BASE =
            "基址:";

        internal const string LIMIT =
            "限制:";

        internal const string SIZE =
            "大小:";

        internal const string FILTER_STARTUP_WINDOW =
            "固件文件 (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|所有文件 (*.*)|*.*";

        internal const string FILTER_EFI_SUPPORTED_FIRMWARE =
            "Apple EFI/BIOS (*.bin, *.rom, *.fd, *.bio)|*.bin;*.rom;*.fd;*.bio|所有文件 (*.*)|*.*";

        internal const string FILTER_SOCROM_SUPPORTED_FIRMWARE =
            "Apple T2 SOCROM (*.bin, *.rom)|*.bin;*.rom|所有文件 (*.*)|*.*";

        internal const string FILTER_BIN =
            "二进制文件 (*.bin, *.rom, *.rgn)|*.bin;*.rom;*.rgn|所有文件 (*.*)|*.*";

        internal const string FILTER_ZIP =
            "Zip 文件 (*.zip)|*.zip";

        internal const string FILTER_LZMA =
            "LZMA 文件 (*.lzma)|*.lzma|所有文件 (*.*)|*.*";

        internal const string FILTER_TEXT =
            "文本文件 (*.txt)|*.txt";

        internal const string FIRMWARE_WINDOWS_OPEN =
            "固件窗口已打开。";

        internal const string QUESTION_RESTART =
            "您确实要重新启动该应用程序吗？";

        internal const string QUESTION_EXIT =
            "您确实要退出该应用程序吗？";

        internal const string SELECT_FOLDER =
            "选择文件夹";

        internal const string RESET_SETTINGS_DEFAULT =
            "这会将所有设置重置为默认设置。您确定要设置默认设置吗？";

        internal const string FILES_SAVE_SUCCESS_NAV =
            "文件保存成功。是否要打开该文件夹？";

        internal const string FILE_SAVE_SUCCESS_NAV =
            "文件保存成功。是否要打开文件位置？";
        #endregion
    }

    internal class LOGSTRINGS
    {
        #region Strings
        internal const string PATCH_START =
            "修补已开始";

        internal const string PATCH_FAIL =
            "修补失败 -";

        internal const string PATCH_SUCCESS =
            "修补成功";

        internal const string CREATING_BUFFERS =
            "创建缓冲区";

        internal const string FILE_EXPORT_CANCELLED =
            "文件导出已取消";

        internal const string VALIDATION_PASS =
            "验证已通过";

        internal const string EXPECTED_STORE_SIZE_NOT =
            "未达到预期的存储大小";

        internal const string STORE_SIG_MISALIGNED =
            "存储签名未对齐或未找到";

        internal const string FSYS_IMPORT_CANCELLED =
            "未提供 Fsys 存储";

        internal const string FSYS_SUM_MASK_SUCCESS =
            "Fsys 校验和屏蔽成功。";

        internal const string FSYS_SUM_INVALID =
            "Fsys 校验和无效";

        internal const string FSYS_SUM_MASK_FAIL =
            "Fsys CRC32 校验和屏蔽失败";

        internal const string FOUND =
            "找到:";

        internal const string CALCULATED =
            "已计算:";

        internal const string MASKING_SUM =
            "掩蔽校验和";

        internal const string SUM_MASKING_FAIL =
            "校验和屏蔽失败";

        internal const string STORE_COMP_FAILED =
            "存储比较检查失败";

        internal const string SSN_BASE_NOT_FOUND =
            "未找到序列号基址";

        internal const string SSN_WTB =
            "将新的 SSN 写入固件缓冲区";

        internal const string HWC_WTB =
            "将新的 HWC 写入固件缓冲区";

        internal const string FSYS_LFB =
            "从固件缓冲区加载 Fsys 存储";

        internal const string SSN_WRITE_SUCCESS =
            "SSN 写入成功";

        internal const string HWC_WRITE_SUCCESS =
            "HWC 写入成功";

        internal const string SSN_NOT_WRITTEN =
            "无法写入新的 SSN";

        internal const string HWC_NOT_WRITTEN =
            "无法写入新的 HWC";

        internal const string IME_IMPORT_CANCELLED =
            "未提供 Intel ME 区域";

        internal const string IME_FPT_NOT_FOUND =
            "未找到 FPT 签名";

        internal const string IME_TOO_LARGE =
            "新的 IME 太大:";

        internal const string IME_TOO_SMALL =
            "新的 IME 更小，并且会自动调整:";

        internal const string IME_VERSION =
            "IME 版本:";

        internal const string IME_BUFFER_MISMATCH =
            "IME 缓冲区不匹配";

        internal const string FILE_SAVE_SUCCESS =
            "文件保存成功 -";

        internal const string NVRAM_VSS_ERASE =
            "擦除变量存储子系统 ($VSS) 存储";

        internal const string NVRAM_SVS_ERASE =
            "擦除安全变量存储 ($SVS)";

        internal const string NVRAM_INIT_HDR =
            "初始化头字节 0x4h > 0x7h (0xFF)";

        internal const string NVRAM_INIT_HDR_VSS =
            "初始化头字节 0x9h > 0xAh (0xFF)";

        internal const string NVRAM_INIT_HDR_FAIL =
            "初始化标头失败";

        internal const string NVRAM_INIT_HDR_SUCCESS =
            "初始化标头成功";

        internal const string CRC_PATCH =
            "修补 CRC32 校验和";

        internal const string CRC_WRITE_TO_FW =
            "将修补的存储写入固件缓冲区";

        internal const string CRC_WRITE_FAIL =
            "写入失败";

        internal const string CRC_WRITE_SUCCESS =
            "写入成功";

        internal const string CRC_BUFFER_EMPTY =
            "缓冲区为空";

        internal const string NVR_BASE_NOT_FOUND =
            "未找到基址 - 跳过";

        internal const string NVR_HAS_BODY_ERASING =
            "有主体数据 - 正在删除";

        internal const string NVR_IS_EMPTY =
            "为空 - 正在跳过";

        internal const string NVR_FAIL_ERASE_BODY =
            "无法删除主体";

        internal const string NVR_FAIL_WRITE_VERIFY =
            "写入验证失败";

        internal const string NVR_ERASE_BODY =
            "删除存储主体数据";

        internal const string NVR_WRITE_ERASED_BODY =
            "将已擦除的主体写回存储";

        internal const string NVR_BODY_WRITE_FAIL =
            "新的存储主体写入失败";

        internal const string NVR_STORE_ERASE_SUCESS =
            "存储擦除成功";

        internal const string AT =
            "在";

        internal const string LOCK_INVALIDATE =
            "EFI 锁定无效";

        internal const string LOCK_PRIMARY_MAC =
            "修补主要消息认证代码";

        internal const string WRITE_NEW_DATA =
            "向固件写入新数据";

        internal const string LOCK_BACKUP_MAC =
            "修补备份消息认证代码";

        internal const string LOCK_LOAD_SVS =
            "从修补的固件加载 NVRAM SVS 存储";

        internal const string LOCK_PRIM_VERIF_FAIL =
            "主 SVS 存储验证失败";

        internal const string LOCK_BACK_VERIF_FAIL =
            "备份 SVS 存储验证失败";

        internal const string SCFG_IMPORT_CANCELLED =
            "未提供 SCfg 存储";

        internal const string SERIAL_LEN_INVALID =
            "序列长度无效";

        internal const string SCFG_REPLACE =
            "替换 SCfg 存储";

        internal const string SCFG_BASE_ADJUST =
            "未找到 SCfg 基址 - 已调整为";

        internal const string SCFG_LFB =
            "从固件缓冲区加载 SCfg 存储";

        internal const string SCFG_POS_INITIALIZED =
            "无法写入 0x28A000h (长度 B8h)，因为存在初始化数据";
        #endregion
    }

    internal class DIALOGSTRINGS
    {
        #region Strings
        internal const string REQUIRES_WIN_10 =
            "此应用程序需要 Windows 10 或更高版本才能运行。应用程序现在将退出。";

        internal const string UNSUPPORTED_OS =
            "不支持的操作系统";

        internal const string UNLOAD_FIRMWARE_RESET =
            "这将卸载固件和所有相关数据。您确定要重置吗？";

        internal const string COULD_NOT_RELOAD =
            "由于未找到文件，因此无法从磁盘重新加载文件。它可能已被移动或删除。";

        internal const string DATA_EXPORT_FAILED =
            "数据导出失败。";

        internal const string ARCHIVE_CREATE_FAILED =
            "备份档案创建失败。";

        internal const string WARN_DATA_MATCHES_BUFF =
            "磁盘上的文件与缓冲区匹配。数据未刷新。";

        internal const string FSYS_SUM_PATCH_FAILED =
            "Fsys 校验和修补失败。";

        internal const string FSYS_SUM_PATCH_SUCCESS =
            "Fsys 校验和修补成功。是否要加载新文件？";

        internal const string FSYS_EXPORT_FAIL =
            "Fsys 存储导出失败。";

        internal const string FSYS_SUM_MASK_FAIL =
            "校验和屏蔽失败。";

        internal const string EFI_LOCK_FAIL =
            "EFI 锁无效失败。";

        internal const string EFI_LOCK_SUCCESS =
            "EFI 锁定失效成功。请确保在首次启动时执行 NVRAM 重置。\r\n是否要加载新文件？";

        internal const string IME_BASE_LIM_NOT_FOUND =
            "未找到管理引擎基址或限制。";

        internal const string S_ME_DIR_FAIL =
            "无法创建 Intel ME 区域目录。";

        internal const string IME_EXPORT_FAIL =
            "Intel ME 导出失败。";

        internal const string LOG_NOT_FOUND =
            "日志文件不存在。";

        internal const string NOT_VALID_FIRMWARE =
            "提供的文件不是有效的固件。";

        internal const string NOT_VALID_EFIROM =
            "提供的文件不是有效的 EFIROM。";

        internal const string NOT_VALID_SOCROM =
            "提供的文件不是有效的 T2 SOCROM。";

        internal const string SCFG_EXPORT_FAIL =
            "SCfg 存储导出失败。";

        internal const string ARCHIVE_EXPORT_FAIL =
            "档案导出失败。";

        internal const string FSYS_PATCH_SUCCESS_SAVE =
            "Fsys 修补成功。是否要保存输出？";

        internal const string FW_SAVED_SUCCESS_LOAD =
            "固件保存成功。是否要加载新文件？";

        internal const string PATCH_FAIL_APP_LOG =
            "修补失败。是否要打开应用程序日志？";

        internal const string IME_PATCH_SUCCESS_SAVE =
            "IME 修补成功。是否要保存输出？";
        #endregion
    }

    internal class STARTUPSTRINGS
    {
        #region Strings
        #endregion
    }

    internal class EFISTRINGS
    {
        #region Strings
        internal const string VSS =
            "VSS";

        internal const string SVS =
            "SVS";

        internal const string FSYS_REGION =
            "FSYS_REGION";

        internal const string ME_REGION =
            "ME_REGION";

        internal const string CRC32 =
            "CRC32";

        internal const string CRC_FIXED =
            "CRC_FIXED";

        internal const string PRIMARY =
            "主要";

        internal const string BACKUP =
            "备份";

        internal const string NOMODEL =
            "无型号";

        internal const string NOSERIAL =
            "序列号";

        internal const string NOFWVER =
            "无固件版本";

        internal const string UNLOCKED =
            "已解锁";

        internal const string LOCKED =
            "已锁定";

        internal const string PRIMARY_REGION =
            "主要区域";

        internal const string BACKUP_REGION =
            "备份区域";

        internal const string CRC_VALID =
            "CRC 有效";

        internal const string CRC_INVALID =
            "CRC 无效";

        internal const string DXE_ARCHIVE =
            "DXE_ARCHIVE";

        internal const string EMPTY =
            "空的";

        internal const string ACTIVE =
            "活动";

        internal const string APFS_DRIVER_FOUND =
            "是（已找到驱动程序）";

        internal const string APFS_DRIVER_NOT_FOUND =
            "否（未找到驱动程序）";

        internal const string MENU_TIP_OPEN =
            "打开 Mac EFI/BIOS";

        internal const string MENU_TIP_COPY =
            "打开复制菜单";

        internal const string MENU_TIP_FOLDERS =
            "打开文件夹菜单";

        internal const string MENU_TIP_EXPORT =
            "打开导出菜单";

        internal const string MENU_TIP_PATCH =
            "打开修补菜单";

        internal const string MENU_TIP_TOOLS =
            "打开工具菜单";

        internal const string MENU_TIP_HELP =
            "打开帮助菜单";

        internal const string MENU_TIP_OPENFILELOCATION =
            "打开文件位置";

        internal const string COPIED_TO_CB_LC =
            "已复制到剪贴板。";

        internal const string FIRMWARE_MOD_FAILED_LOG =
            "固件修改失败。要查看应用程序日志吗？";

        internal const string FIRMWARE_MOD_SUCCESS_SAVE =
            "固件修改成功。是否要保存输出？";

        internal const string LZMA_VOL_FOUND =
            "固件中检测到 LZMA DXE 存档";

        internal const string FMM_EMAIL_FOUND =
            "查找在 NVRAM 中检测到的我的 Mac 电子邮件（点击查看）";

        internal const string FMM_EMAIL =
            "FindMyMac_Email";
        #endregion
    }

    internal class SOCSTRINGS
    {
        #region Strings
        internal const string SCFG_REGION =
            "SCFG_REGION";

        internal const string MENU_TIP_OPEN =
           "打开一个 T2 SOCROM";

        internal const string MENU_TIP_COPY =
            "打开复制菜单";

        internal const string MENU_TIP_FOLDERS =
            "打开文件夹菜单";

        internal const string MENU_TIP_EXPORT =
            "打开导出菜单";

        internal const string MENU_TIP_PATCH =
            "打开修补菜单";

        internal const string MENU_TIP_TOOLS =
            "打开工具菜单";

        internal const string MENU_TIP_HELP =
            "打开帮助菜单";

        internal const string MENU_TIP_OPENFILELOCATION =
            "打开文件位置";
        #endregion
    }
}
