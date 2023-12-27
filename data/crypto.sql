CREATE TABLE IF NOT EXISTS binance_data (
    id SERIAL PRIMARY KEY,
    symbol VARCHAR(10),
    price NUMERIC(10,8),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

COMMENT ON TABLE binance_data IS 'Stores data from Binance API for symbol BNBBTC';
COMMENT ON COLUMN binance_data.symbol IS 'Symbol of the cryptocurrency';
COMMENT ON COLUMN binance_data.price IS 'Price of the cryptocurrency';
COMMENT ON COLUMN binance_data.created_at IS 'Timestamp of the data insertion';
