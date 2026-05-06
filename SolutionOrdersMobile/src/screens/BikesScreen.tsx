import React from 'react';
import {
  View,
  Text,
  StyleSheet,
  FlatList,
  TouchableOpacity,
} from 'react-native';
import AppLayout from '../components/AppLayout';
import BikeCard from '../components/BikeCard';

type Props = {
  onBack: () => void;
};

const bikes = [
  { id: 1, name: 'Trek Marlin 5', type: 'Górski', pricePerHour: 15, status: 'Dostępny' },
  { id: 2, name: 'Kross Evado', type: 'Trekkingowy', pricePerHour: 12, status: 'Wypożyczony' },
  { id: 3, name: 'Cannondale Trail', type: 'MTB', pricePerHour: 18, status: 'Dostępny' },
  { id: 4, name: 'Romet Wagant', type: 'Miejski' ,pricePerHour: 10, status: 'Serwis' },
];

export default function BikesScreen({ onBack }: Props) {
  return (
    <AppLayout>
      <TouchableOpacity onPress={onBack}>
        <Text style={styles.back}>← Wróć</Text>
      </TouchableOpacity>

      <Text style={styles.title}>Lista rowerów</Text>

      <FlatList
        data={bikes}
        keyExtractor={(item) => item.id.toString()}
        renderItem={({ item }) => <BikeCard {...item} />}
        contentContainerStyle={{ gap: 12, paddingBottom: 30 }}
      />
    </AppLayout>
  );
}

const styles = StyleSheet.create({
  back: {
  color: '#E5A24A',
  marginBottom: 16,
  fontWeight: '600',
  fontSize: 16, // 👈 dodaj
},
  title: {
    color: '#F9FAFB',
    fontSize: 28,
    marginBottom: 20,
    fontWeight: 'bold',
  },
});