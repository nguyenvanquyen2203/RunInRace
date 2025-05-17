Link video Game: https://youtu.be/GM7xgnwhHdI
RunInRace
1. Giới thiệu
RunInRace là tựa game 3D của tôi. Lấy ý tưởng từ tựa game nổi tiếng Subway Surfers. Đây là tựa game tôi áp dụng tất cả kiến thức 3D tôi đã học.
2. Thể loại
Endless Runner.
3. Điểm nhấn
3.1. Cơ chế chạy tại chỗ
   Hệ thống map di chuyển ngược về phía người chơi giúp dễ dàng Spawn Race Object.
3.2. Hệ thống spawn object:
   Từ điển: Race Object: Các vật phẩm trên đường như các vật cản (Sign, Tonel, Car), các item (coin, buff item, ...), đèn đường.
   Dự án kết hợp các Design Pattern để tạo hệ thống SpawnObject hoàn chỉnh game Mode (DayMode và NightMode): Singleton, ObjectPooling để quản lý các Race Object, Observer Pattern để quan sát và sử lý các sự kiện khởi tạo, bắt đầu, dừng trò chơi.
   ## Hình minh họa
   - Khởi tạo các Object cần thiết và nạp vào pool.
<!-- end list -->
   ![image](https://github.com/user-attachments/assets/5ba203f5-a549-468b-8cee-f711cc03d9b0)
<!-- end list -->
   ![image](https://github.com/user-attachments/assets/4b732425-2fe0-461e-b9ae-94b1c6ba45f5)
   - Sử dụng ScriptableObject lưu data 1 đoạn đường + Spawn ngẫu nhiên tạo cảm giác không bị trùng lặp.
<!-- end list -->
   ![image](https://github.com/user-attachments/assets/b36a54f1-1f58-4ef6-925c-f21911464b5f)
   - Observer cho quản lý sự kiện bắt đầu và kết thúc trò chơi.
<!-- end list -->
   ![image](https://github.com/user-attachments/assets/337fdf93-3a6a-4d00-9b99-b06f5980cf60)
	- Observer cho quản lý các sự kiện di chuyển map.
<!-- end list -->
   ![image](https://github.com/user-attachments/assets/a8351636-4710-4a09-b783-52c62da00a10)
<!-- end list -->
- Đoạn code sử dụng kết hợp singleton + Object pooling để hỗ trợ quản lý RaceObject
   ![image](https://github.com/user-attachments/assets/eb3b9bf9-3a9e-4919-8868-f151f282d4ad)
<!-- end list -->
3.3. Cơ chế tăng tốc theo thời gian
   Set lại tốc độ của map mỗi khi spawn map từ RaceObjectController.
   Với các map đang được kích hoạt, Sử dụng Observer Pattern để thay đổi tốc độ của map. 
3.4. Hệ thống AudioManager để quản lý nhạc nền (music) và SFXmusic
![image](https://github.com/user-attachments/assets/a6c859cd-354a-4e5f-8e6b-a337fd8a408f)
