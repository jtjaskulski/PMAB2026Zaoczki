import React from 'react';
import { View, Text, StyleSheet } from 'react-native';

type Props = {
  name: string;
  type: string;
  pricePerHour: number;
  status: string;
};

export default function BikeCard({ name, type, pricePerHour, status }: Props) {
  return (
    <View style={styles.card}>
      <Text style={styles.name}>{name}</Text>
      <Text style={styles.type}>{type}</Text>

      <View style={styles.row}>
        <Text style={styles.price}>{pricePerHour} zł/h</Text>

        <View
          style={[
            styles.statusBadge,
            status === 'Dostępny' && styles.available,
            status === 'Wypożyczony' && styles.rented,
            status === 'Serwis' && styles.service,
          ]}
        >
          <Text style={styles.statusText}>{status}</Text>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  card: {
    backgroundColor: '#1E293B',
    padding: 18,
    borderRadius: 18,
    borderWidth: 1,
    borderColor: '#334155',
  },
  name: {
    color: '#F9FAFB',
    fontSize: 19,
    fontWeight: 'bold',
  },
  type: {
    color: '#94A3B8',
    marginTop: 5,
    fontSize: 14,
  },
  row: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
    marginTop: 16,
  },
  price: {
    color: '#E5A24A',
    fontWeight: '700',
    fontSize: 20, 
},
  statusBadge: {
    paddingVertical: 7,
    paddingHorizontal: 13,
    borderRadius: 20,
  },
  available: {
    backgroundColor: '#14532D',
  },
  rented: {
    backgroundColor: '#7F1D1D',
  },
  service: {
    backgroundColor: '#78350F',
  },
  statusText: {
    color: '#FFFFFF',
    fontSize: 12,
    fontWeight: '700',
  },
});