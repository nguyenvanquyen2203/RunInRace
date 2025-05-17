Link video Game: https://youtu.be/GM7xgnwhHdI
RunInRace
1. Giới thiệu
RunInRace là tựa game 3D của tôi. Lấy ý tưởng từ tựa game nổi tiếng Subway Surfers. Đây là tựa game tôi áp dụng tất cả kiến thức 3D tôi đã học.
2. Thể loại
Endless Runner.
3. Điểm nhấn
3.1. Hệ thống spawn object:
   Từ điển: Race Object: Các vật phẩm trên đường như các vật cản (Sign, Tonel, Car), các item (coin, buff item, ...), đèn đường.

   Dự án kết hợp các Design Pattern để tạo hệ thống SpawnObject hoàn chỉnh game Mode (DayMode và NightMode): Singleton, ObjectPooling để quản lý các Race Object, Observer Pattern để quan sát và sử lý các sự kiện khởi tạo, bắt đầu, dừng trò chơi.
   Hình minh họa:
   ![image](https://github.com/user-attachments/assets/5ba203f5-a549-468b-8cee-f711cc03d9b0)
   ![image](https://github.com/user-attachments/assets/4b732425-2fe0-461e-b9ae-94b1c6ba45f5)
   Khởi tạo các Object cần thiết và nạp vào pool.
   Observer Pattern để hỗ trợ quản lý các sự kiện của game.
   ![image](https://github.com/user-attachments/assets/337fdf93-3a6a-4d00-9b99-b06f5980cf60)
  Observer cho quản lý sự kiện bắt đầu và kết thúc trò chơi.
  ![image](https://github.com/user-attachments/assets/1b82090d-8987-49b4-8a65-57140497a3f2)
  Observer cho quản lý các sự kiện di chuyển map.
