-- Insert seed data for auction_type table
INSERT INTO auction_type (type) VALUES
                                    ('English Auction'),
                                    ('Dutch Auction'),
                                    ('Silent Auction');

-- Insert seed data for variety table
INSERT INTO variety (name) VALUES
                               ('Painting'),
                               ('Sculpture'),
                               ('Jewelry'),
                               ('Antique');

-- Insert seed data for user table
INSERT INTO [user] (email, phone, password, admin) VALUES
    ('user1@example.com', 123456789, 'hashed_password_1', 0),
    ('user2@example.com', 987654321, 'hashed_password_2', 0),
    ('admin@example.com', NULL, 'hashed_admin_password', 1);

-- Insert seed data for product table
INSERT INTO product (name, variety_id, stock) VALUES
                                                  ('Artwork 1', 1, 10),
                                                  ('Sculpture 1', 2, 5),
                                                  ('Necklace 1', 3, 20),
                                                  ('Antique Item 1', 4, 8);

-- Insert seed data for auction table
INSERT INTO auction (auction_type_id, product_id, minimum_value, initial_value, increment, start, [end], current_bid, status) VALUES
                                                                                                                                  (1, 1, 100, 200, 10, '2024-01-20 12:00:00', '2024-01-25 18:00:00', NULL, 1),
                                                                                                                                  (2, 2, 50, 150, 5, '2024-01-21 10:00:00', '2024-01-24 15:00:00', NULL, 1),
                                                                                                                                  (3, 3, 200, 300, 20, '2024-01-22 15:00:00', '2024-01-27 20:00:00', NULL, 1);

-- Insert seed data for bidding table
INSERT INTO bidding (time, value, auction_id, user_id) VALUES
                                                           ('2024-01-20 14:30:00', 250, 1, 1),
                                                           ('2024-01-22 11:45:00', 180, 2, 2),
                                                           ('2024-01-23 18:20:00', 320, 3, 3);
